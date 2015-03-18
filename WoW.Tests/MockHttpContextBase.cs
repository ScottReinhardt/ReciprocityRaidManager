using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NSubstitute;

namespace WoW.Tests
{
    /// <summary>
    /// Mocks an entire HttpContext for use in unit tests
    /// </summary>
    public class MockHttpContextBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MockHttpContextBase"/> class.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="url">The URL.</param>
        public MockHttpContextBase(ControllerBase controller, string url)
        {
            HttpContext = Substitute.For<HttpContextBase>();
            Request = Substitute.For<HttpRequestBase>();
            Response = Substitute.For<HttpResponseBase>();
            Output = new StringBuilder();

            HttpContext.Request.Returns(Request);
            HttpContext.Response.Returns(Response);
            HttpContext.Session.Returns(new FakeSessionState());

            Request.Cookies.Returns(new HttpCookieCollection());
            Request.QueryString.Returns(new NameValueCollection());
            Request.Form.Returns(new NameValueCollection());
            Request.ApplicationPath.Returns("~/");
            Request.AppRelativeCurrentExecutionFilePath.Returns(url);
            Request.PathInfo.Returns(string.Empty);

            Response.Cookies.Returns(new HttpCookieCollection());
            Response.ApplyAppPathModifier(Arg.Any<string>()).Returns(p => p.Arg<string>());
            Response.When(r => r.Write(Arg.Any<string>())).Do(s => Output.Append(s)); ;

            var requestContext = new RequestContext(HttpContext, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);
        }

        /// <summary>
        /// Gets the HTTP context.
        /// </summary>
        /// <value>The HTTP context.</value>
        public HttpContextBase HttpContext { get; private set; }

        /// <summary>
        /// Gets the request.
        /// </summary>
        /// <value>The request.</value>
        public HttpRequestBase Request { get; private set; }

        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <value>The response.</value>
        public HttpResponseBase Response { get; private set; }

        /// <summary>
        /// Gets the output.
        /// </summary>
        /// <value>The output.</value>
        public StringBuilder Output { get; private set; }
    }

    /// <summary>
    /// Provides Fake Session for use in unit tests
    /// </summary>
    public class FakeSessionState : HttpSessionStateBase
    {
        /// <summary>
        /// backing field for the items in session
        /// </summary>
        private readonly Dictionary<string, object> _items = new Dictionary<string, object>();

        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> with the specified name.
        /// </summary>
        /// <param name="name">the key</param>
        /// <returns>the value in session</returns>
        public override object this[string name]
        {
            get
            {
                return _items.ContainsKey(name) ? _items[name] : null;
            }
            set
            {
                _items[name] = value;
            }
        }
    }
}