using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using POSCreditRepayments.Data;
using POSCreditRepayments.Models;

namespace POSCreditRepayments.Web.Controllers
{
    [HandleError]
    public abstract class BaseController : Controller
    {
        private User currentUser;

        public BaseController(IPOSCreditRepaymentsData data)
        {
            this.Data = data;
        }


        protected IPOSCreditRepaymentsData Data { get; set; }

        protected User CurrentUser
        {
            get
            {
                if (this.currentUser == null)
                {
                    var userId = User.Identity.GetUserId();
                    var user = this.Data.Users.GetById(userId);
                    this.currentUser = user;
                }

                return this.currentUser;
            }
            set
            {
                this.currentUser = value;
            }
        }
    }
}
