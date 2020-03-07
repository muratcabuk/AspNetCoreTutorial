using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentSpecification.Abstractions.Validation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using SMS.Core.Entities;
using SMS.Globalizaiton.Resources;

namespace SMS.Core.Web.Extensions
{
    public static class AspNetExtensions
    {

        public static void FromSpec(this ModelStateDictionary modelState, IReadOnlyList<FailedSpecification> failedSpecifications)
        {

            foreach (var resultFailedSpecification in failedSpecifications)
            {
                var key = resultFailedSpecification.Parameters.Where(t => t.Key == "PropertyName").FirstOrDefault();

                if (key.Value != null)
                {
                    foreach (var error in resultFailedSpecification.Errors)
                    {
                        modelState.AddModelError(key.Value.ToString(), error);
                    }


                }

            }

        }



        public static List<SelectListItem> ToSelectList(this List<Option<int, String>> optionList)
        {

            var list = new List<SelectListItem>();

            list.Add(new SelectListItem { Value = "-1", Text = Resource.Select, Selected = true });

            foreach (var option in optionList)
            {
                list.Add(new SelectListItem { Value = option.Id.ToString(), Text = option.Title });
            }

            return list;

        }





    }
}
