
using BlackhawkDesign.Web.Models;
using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Api;
using IntelliTect.Coalesce.Api.Controllers;
using IntelliTect.Coalesce.Api.DataSources;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Mapping.IncludeTrees;
using IntelliTect.Coalesce.Models;
using IntelliTect.Coalesce.TypeDefinition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BlackhawkDesign.Web.Api
{
    [Route("api/JobApplication")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class JobApplicationController
        : BaseApiController<BlackhawkDesign.Data.Models.JobApplication, JobApplicationDtoGen, BlackhawkDesign.Data.AppDbContext>
    {
        public JobApplicationController(CrudContext<BlackhawkDesign.Data.AppDbContext> context) : base(context)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<BlackhawkDesign.Data.Models.JobApplication>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<JobApplicationDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<BlackhawkDesign.Data.Models.JobApplication> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<JobApplicationDtoGen>> List(
            ListParameters parameters,
            IDataSource<BlackhawkDesign.Data.Models.JobApplication> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<BlackhawkDesign.Data.Models.JobApplication> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<JobApplicationDtoGen>> Save(
            [FromForm] JobApplicationDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<BlackhawkDesign.Data.Models.JobApplication> dataSource,
            IBehaviors<BlackhawkDesign.Data.Models.JobApplication> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<JobApplicationDtoGen>> Delete(
            int id,
            IBehaviors<BlackhawkDesign.Data.Models.JobApplication> behaviors,
            IDataSource<BlackhawkDesign.Data.Models.JobApplication> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
