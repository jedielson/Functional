namespace Functional.Mvc.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class ConfirmationExtensions
    {
        public static MvcHtmlString DeleteConfirmation(
            this AjaxHelper helper,
            string linkText,
            string message,
            Guid modelId,
            string action,
            string controller,
            IDictionary<string, object> htmlAttributes)
        {
            var routeValues = new RouteValueDictionary
                                  {
                                      { "ModelId", modelId },
                                      { "Message", message },
                                      { "ActionDelete", action },
                                      { "ControllerDelete", controller }
                                  };
            return helper.ModalDialogActionLink(linkText, "Confirmation", "Messages", string.Empty, routeValues, htmlAttributes);
        }

        public static MvcHtmlString DeleteConfirmation(
            this AjaxHelper helper,
            string linkText,
            string message,
            Guid modelId,
            string action,
            string controller,
            IDictionary<string, object> htmlAttributes,
            string callbackJs)
        {
            var routeValues = new RouteValueDictionary
                                  {
                                      { "ModelId", modelId },
                                      { "Message", message },
                                      { "ActionDelete", action },
                                      { "ControllerDelete", controller }
                                  };
            return helper.ModalDialogActionLink(linkText, "Confirmation", "Messages", string.Empty, routeValues, htmlAttributes, callbackJs);
        }
    }
}