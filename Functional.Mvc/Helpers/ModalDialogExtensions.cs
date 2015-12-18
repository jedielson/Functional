namespace Functional.Mvc.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Script.Serialization;
    using System.Web.WebPages;

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
        /// <param name="ajaxHelper">The ajax helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="actionName">The action name.</param>
        /// <param name="controllerName">The controller name.</param>
        /// <param name="dialogTitle">The dialog title.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The html values.</param>
        /// <param name="inputDeRetornoJson">Id para retorno de dados para página.</param>
        /// <param name="callback">Callback JS</param>
        /// <returns>The <see cref="MvcHtmlString"/>.</returns>
        public static MvcHtmlString ModalDialogActionLink(
            this AjaxHelper ajaxHelper,
            string linkText,
            string actionName,
            string controllerName,
            string dialogTitle,
            RouteValueDictionary routeValues,
            IDictionary<string, object> htmlAttributes,
            string inputDeRetornoJson,
            string callback)
        {
            if (routeValues == null)
            {
                routeValues = new RouteValueDictionary();
            }

            routeValues.Add("inputRetornoJson", inputDeRetornoJson);
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
                        OnSuccess = string.Format(CultureInfo.InvariantCulture, "openModalDialog('{0}', '{1}', '{2}',{3})", dialogDivId, dialogTitle, inputDeRetornoJson, callback)
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
        /// Executa a action result de um Dialog
        /// </summary>
        /// <param name="controller">O controller atual</param>
        /// <param name="message">A mensagem para o usuário</param>
        /// <param name="jsonDialogResult">os dados a serem retornados</param>
        /// <returns>Um <see cref="ActionResult"/></returns>
        public static ActionResult DialogResult(
            this Controller controller,
            string message,
            JsonDialogResult jsonDialogResult)
        {
            return new DialogActionResult(message, jsonDialogResult);
        }

        /// <summary>
        /// The dialog result.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public static ActionResult DialogResult(this Controller controller)
        {
            return DialogResult(controller, string.Empty, null);
        }

        /// <summary>
        /// The dialog result.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="message">The message.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public static ActionResult DialogResult(this Controller controller, string message)
        {
            return DialogResult(controller, message, null);
        }

        /// <summary>
        /// Representa o retorno Json de um PopUp
        /// </summary>
        public sealed class JsonDialogResult
        {
            /// <summary>
            /// Inicializa uma nova instância de <see cref="JsonDialogResult"/>.
            /// </summary>
            /// <param name="id">o id do input</param>
            /// <param name="data">o objeto a ser serializado</param>
            public JsonDialogResult(string id, object data)
            {
                this.ValidaDados(id, data);
                this.HiddenId = id;
                this.Data = data;
            }

            /// <summary>
            /// Os dados a serem serializados
            /// </summary>
            public object Data { get; set; }

            /// <summary>
            /// O Id do Hidden onde os dados ficarão armazenados
            /// </summary>
            public string HiddenId { get; set; }

            /// <summary>
            /// Valida os dados de retorno
            /// </summary>
            /// <param name="id">o id do input</param>
            /// <param name="data">o objeto a ser serializado</param>
            // ReSharper disable once UnusedParameter.Local
            private void ValidaDados(string id, object data)
            {
                if (id == null || id.Trim().IsEmpty())
                {
                    throw new ArgumentException("O id do Input de Saída não pode ser nulo");
                }

                if (data == null)
                {
                    throw new ArgumentException("Os dados de saída não podem ser nulos.");
                }
            }
        }

        /// <summary>
        /// Classe DialogActionResult
        /// </summary>
        internal sealed class DialogActionResult : ActionResult
        {
            /// <summary>
            /// Inicializa um <see cref="DialogActionResult"/>
            /// </summary>
            /// <param name="message">Uma mensagem</param>
            /// <param name="jsonDialogResult">Um resultado a ser serializado em Json</param>
            public DialogActionResult(string message, JsonDialogResult jsonDialogResult)
            {
                this.Json = jsonDialogResult;
                this.Message = message ?? string.Empty;
            }

            /// <summary>
            /// Gets or sets the message.
            /// </summary>
            public string Message { get; set; }

            /// <summary>
            /// Gets or sets the data.
            /// </summary>
            public JsonDialogResult Json { get; set; }

            /// <summary>
            /// The execute result.
            /// </summary>
            /// <param name="context">
            /// The context.
            /// </param>
            public override void ExecuteResult(ControllerContext context)
            {
                if (this.Json != null)
                {
                    this.SalvaDadosJson(context);
                }

                context.HttpContext.Response.Write(
                    string.Format("<div data-dialog-close='true' data-dialog-result='{0}' />", this.Message));
            }

            /// <summary>
            /// Escreve um input HIDDEN que armazena um objeto Json
            /// </summary>
            /// <param name="context">O HttpContext da chamada</param>
            private void SalvaDadosJson(ControllerContext context)
            {
                string input = "<input type='hidden' id='{0}' value='{1}'/>";
                var serializer = new JavaScriptSerializer();
                input = string.Format(input, this.Json.HiddenId, serializer.Serialize(this.Json.Data));
                context.HttpContext.Response.Write(input);
            }
        }
    }
}