 public abstract class AuthorizeAttributeBase : AuthorizationFilterAttribute
    {
        public abstract bool IsAuthorized(AuthFilterContext context); // This method is overrided in both the subclass

        public override void OnAuthorization(HttpActionContext actionContext) // 1.Call by Framework
        {
            if (SkipAuthorization(actionContext))// Call the SkipAuthorization of CustomSupportedModulesAttribute class
            {
                return;
            }
			return IsAuthorized(actionContext)// Call the IsAuthorized of CustomSupportedModulesAttribute class
        }

        protected virtual bool SkipAuthorization(HttpActionContext actionContext)
        {
            return false;
        }
    }
	
	
 public abstract class SupportedModuleAttribute : AuthorizeAttributeBase
    {
        public override bool IsAuthorized(AuthFilterContext context)
		{
				// Some Logic
		}

        protected override bool SkipAuthorization(HttpActionContext actionContext)
        {
            return false;
        }
    }
	
public class CustomSupportedModulesAttribute : SupportedModuleAttribute
    {
		public override bool IsAuthorized(AuthFilterContext context)
		{
			base.IsAuthorized();// call the IsAuthorized of SupportedModuleAttribute class
		}
		
        protected override bool SkipAuthorization(HttpActionContext actionContext)
        {
            return base.SkipAuthorization(actionContext); // call the SkipAuthorization of SupportedModuleAttribute class
        }
    }
	
	