using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Managers;
using Models.Enums;

namespace Web.Extensions
{
    /// <summary>
    /// Container for extension methods assosiated with dropdown lists.
    /// </summary>
    public static class DropDownInfoExtensions
    {
        /// <summary>
        /// Generates DropDown list for roles names in system.
        /// </summary>
        /// <param name="html"></param>
        /// <returns>Select list items of roles</returns>

        public static IEnumerable<SelectListItem> GetListItemsForRoles(this HtmlHelper html) { 
            return Roles.GetAllRoles().Select(name => new SelectListItem()
            {
                Text = name,
                Value = name,
                Selected = name == "User"
            });
        }
    }
}
