namespace Functional.Mvc.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;

    using Functional.Mvc.Helpers.ResultsExtensions;

    /// <summary>
    /// Cabeçalho teste
    /// </summary>
    public static class ModalDialogExtensions
    {
        /// <summary>
        /// The modal dialog action link.
        /// </summary>
        /// <param name="ajaxHelper">The ajax helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="actionName">The action name.</param>
        /// <param name="controllerName">The controller name.</param>
        /// <param name="dialogTitle">The dialog title.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The html values.</param>
        /// <returns>The <see cref="MvcHtmlString"/>.</returns>
        public static MvcHtmlString ModalDialogActionLink(
            this AjaxHelper ajaxHelper,
            string linkText,
            string actionName,
            string controllerName,
            string dialogTitle,
            RouteValueDictionary routeValues,
            IDictionary<string, object> htmlAttributes)
        {
            var dialogDivId = Guid.NewGuid().ToString();
            return ajaxHelper.ActionLink(
                linkText,
                actionName,
                controllerName,
                routeValues: routeValues,
                ajaxOptions:
                    new AjaxOptions
                    {
                        UpdateTargetId = dialogDivId,
                        InsertionMode = InsertionMode.Replace,
                        HttpMethod = "GET",
                        OnBegin = string.Format(CultureInfo.InvariantCulture, "prepareModalDialog('{0}')", dialogDivId),
                        OnFailure = string.Format(CultureInfo.InvariantCulture, "clearModalDialog('{0}');alert('Ajax call failed')", dialogDivId),
                        OnSuccess = string.Format(CultureInfo.InvariantCulture, "openModalDialog('{0}', '{1}')", dialogDivId, dialogTitle)
                    },
                htmlAttributes: htmlAttributes);
        }

        /// <summary>
        /// The modal dialog action link.
        /// </summary>
        /// <param name="ajaxHelper">Um Helper Ajax.</param>
        /// <param name="linkText">O texto a ser exibido no link</param>
        /// <param name="actionName">A Action a ser executada quando o link for clicado</param>
        /// <param name="controllerName">O nome do controller</param>
        /// <param name="dialogTitle">O título do modal popUp a ser exibido</param>
        /// <param name="routeValues">Valores de Rota</param>
        /// <param name="htmlAttributes">html atributes</param>
        /// <param name="onSubmitJsCallback">
        /// Um Callback JS a ser executado após o submit
        /// <para></para>
        /// Este callback deve ser criado de forma a receber uma conjunto de dados no formato Json.
        /// Ex: function callback(data){}
        /// Para informar quais dados devem ser submetidos, deve-se retornar um <see cref="ModalActionResult"/>, 
        /// endo o último parâmetro, um <see cref="object"/> que será serializado.
        /// Após a submissão do formulário, caso não seja especificado um callback, os dados serão descartados.
        /// </param>
        /// <returns>The <see cref="MvcHtmlString"/>.</returns>
        public static MvcHtmlString ModalDialogActionLink(
            this AjaxHelper ajaxHelper,
            string linkText,
            string actionName,
            string controllerName,
            string dialogTitle,
            RouteValueDictionary routeValues,
            IDictionary<string, object> htmlAttributes,
            string onSubmitJsCallback)
        {
            if (routeValues == null)
            {
                routeValues = new RouteValueDictionary();
            }

            var dialogDivId = Guid.NewGuid().ToString();
            return ajaxHelper.ActionLink(
                linkText,
                actionName,
                controllerName,
                routeValues: routeValues,
                ajaxOptions:
                    new AjaxOptions
                    {
                        UpdateTargetId = dialogDivId,
                        InsertionMode = InsertionMode.Replace,
                        HttpMethod = "GET",
                        OnBegin = string.Format(CultureInfo.InvariantCulture, "prepareModalDialog('{0}')", dialogDivId),
                        OnFailure = string.Format(CultureInfo.InvariantCulture, "clearModalDialog('{0}');alert('Ajax call failed')", dialogDivId),
                        OnSuccess = string.Format(CultureInfo.InvariantCulture, "openModalDialog('{0}', '{1}', {2})", dialogDivId, dialogTitle, onSubmitJsCallback)
                    },
                htmlAttributes: htmlAttributes);
        }

        /// <summary>
        /// The begin modal dialog form.
        /// </summary>
        /// <param name="ajaxHelper">The ajax helper.</param>
        /// <returns>The <see cref="MvcForm"/>.</returns>
        public static MvcForm BeginModalDialogForm(this AjaxHelper ajaxHelper)
        {
            // ReSharper disable once Mvc.ActionNotResolved
            return ajaxHelper.BeginForm(new AjaxOptions { HttpMethod = "POST" });
        }

        /// <summary>
        /// The begin modal dialog form.
        /// </summary>
        /// <param name="ajaxHelper">The ajax helper.</param>
        /// <param name="action">A action para onde o form será submetido</param>
        /// <param name="controller">O controller da action</param>
        /// <returns>The <see cref="MvcForm"/>.</returns>
        public static MvcForm BeginModalDialogForm(this AjaxHelper ajaxHelper, string action, string controller)
        {
            // ReSharper disable once Mvc.ActionNotResolved
            return ajaxHelper.BeginForm(action, controller, new AjaxOptions { HttpMethod = "POST" });
        }



        /// <summary>
        /// Executa a action result de um Dialog
        /// </summary>
        /// <param name="controller">O controller atual</param>
        /// <param name="message">A mensagem para o usuário</param>
        /// <param name="jsonDialogResult">os dados a serem retornados</param>
        /// <returns>Um <see cref="ActionResult"/></returns>
        public static ActionResult JsonDialogResult(
            this Controller controller,
            string message,
            object jsonDialogResult)
        {
            return new JsonDialogActionResult(message, jsonDialogResult);
        }

        /// <summary>
        /// The dialog result.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public static ActionResult JsonDialogResult(this Controller controller)
        {
            return JsonDialogResult(controller, string.Empty, null);
        }

        /// <summary>
        /// The dialog result.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="message">The message.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public static ActionResult JsonDialogResult(this Controller controller, string message)
        {
            return JsonDialogResult(controller, message, null);
        }

        /// <summary>
        /// Executa a action result de um Dialog
        /// </summary>
        /// <param name="controller">O controller atual</param>
        /// <param name="message">A mensagem para o usuário</param>
        /// <param name="viewName">O nome da View</param>
        /// <param name="jsonDialogResult">os dados a serem retornados</param>
        /// <returns>Um <see cref="ActionResult"/></returns>
        public static ActionResult HtmlDialogResult(
            this Controller controller,
            string message,
            string viewName,
            object jsonDialogResult)
        {
            return new HtmlDialogActionResult(message, viewName, jsonDialogResult);
        }

        /// <summary>
        /// The dialog result.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public static ActionResult HtmlDialogResult(this Controller controller)
        {
            return HtmlDialogResult(controller, string.Empty, null, null);
        }

        /// <summary>
        /// The dialog result.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="message">The message.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public static ActionResult HtmlDialogResult(this Controller controller, string message)
        {
            return HtmlDialogResult(controller, message, null, null);
        }
    }
}