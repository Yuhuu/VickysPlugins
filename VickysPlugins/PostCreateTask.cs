
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

/// <summary>
/// This plugin trigger when there is new lead created.
/// </summary>
/// namespace LeadProcess
/// 
namespace LeadProcess
{
    public class PostCreateTask : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // Obtain the execution context from the service provider.
            IPluginExecutionContext context = (IPluginExecutionContext)
               serviceProvider.GetService(typeof(IPluginExecutionContext));

            // The InputParameters collection contains all the data
            //passed in the message request.
            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
     {

                // Obtain the target entity from the input parameters.
                Entity entity = (Entity)context.InputParameters["Target"];
                try
                {

                    // Create a lead 
                    Entity followup = new Entity("lead");

                    // Refer to the lead 

                    Guid regardingobjectid = entity.Id;
                    //new Guid(context.OutputParameters["id"].ToString());

                        followup["emailaddress1"] = "hello@gasss";
                        followup["leadid"] = regardingobjectid;

                        // Obtain the organization service reference.
                        IOrganizationServiceFactory serviceFactory =
                           (IOrganizationServiceFactory)serviceProvider.GetService
                           (typeof(IOrganizationServiceFactory));
                        IOrganizationService service =
                           serviceFactory.CreateOrganizationService(context.UserId);
                        service.Update(followup);

                 
                    // Here should alarm something if there is no ID found
                    // Todo>
                }
                catch (Exception ex)
                {
                    throw new InvalidPluginExecutionException(ex.Message);
                }
            }
        }
    }
}
