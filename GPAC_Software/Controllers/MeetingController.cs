using GPAC_Software.Models;
using GPAC_Software.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace GPAC_Software.Controllers
{
    public class MeetingController : Controller
    {
        private readonly AppDbContext _context;

        public MeetingController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Products = _context.ProductServices.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult LoadCustomers(string type)
        {
            if (type == "Corporate")
            {
                var customers = _context.CorporateCustomers.Select(c => new { c.Id, c.Name }).ToList();
                return Json(customers);
            }
            else if (type == "Individual")
            {
                var customers = _context.IndividualCustomers.Select(c => new { c.Id, c.Name }).ToList();
                return Json(customers);
            }
            return Json(new { error = "Invalid customer type" });
        }

        [HttpPost]
        public IActionResult SaveMeeting([FromBody] MeetingViewModel model)
        {
            if (model == null || model.Details == null || !model.Details.Any())
            {
                return BadRequest("Invalid data.");
            }

            var masterId = 0;
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Meeting_Minutes_Master_Save_SP";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@CustomerId", model.CustomerId));
                command.Parameters.Add(new SqlParameter("@CustomerType", model.CustomerType));
                command.Parameters.Add(new SqlParameter("@Date", model.Date));
                command.Parameters.Add(new SqlParameter("@Time", model.Time));
                command.Parameters.Add(new SqlParameter("@MeetingPlace", model.MeetingPlace));
                command.Parameters.Add(new SqlParameter("@AttendeesClientSide", model.AttendeesClientSide));
                command.Parameters.Add(new SqlParameter("@AttendeesHostSide", model.AttendeesHostSide));
                command.Parameters.Add(new SqlParameter("@MeetingAgenda", model.MeetingAgenda));
                command.Parameters.Add(new SqlParameter("@MeetingDiscussion", model.MeetingDiscussion));
                command.Parameters.Add(new SqlParameter("@MeetingDecision", model.MeetingDecision));
                var outputParam = new SqlParameter("@MasterId", SqlDbType.Int) { Direction = ParameterDirection.Output };
                command.Parameters.Add(outputParam);

                _context.Database.OpenConnection();
                command.ExecuteNonQuery();
                masterId = (int)outputParam.Value;
            }

            foreach (var detail in model.Details)
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "Meeting_Minutes_Details_Save_SP";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@MasterId", masterId));
                    command.Parameters.Add(new SqlParameter("@ProductId", detail.ProductId));
                    command.Parameters.Add(new SqlParameter("@Quantity", detail.Quantity));

                    _context.Database.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }

            return Ok(new { success = true, message = "Meeting saved successfully!" });
        }
    }
}
