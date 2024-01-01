
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
    [Route("api/Job")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class JobController
        : BaseApiController<BlackhawkDesign.Data.Models.Job, JobDtoGen, BlackhawkDesign.Data.AppDbContext>
    {
        public JobController(CrudContext<BlackhawkDesign.Data.AppDbContext> context) : base(context)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<BlackhawkDesign.Data.Models.Job>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<JobDtoGen>> Get(
            string id,
            DataSourceParameters parameters,
            IDataSource<BlackhawkDesign.Data.Models.Job> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<JobDtoGen>> List(
            ListParameters parameters,
            IDataSource<BlackhawkDesign.Data.Models.Job> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<BlackhawkDesign.Data.Models.Job> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<JobDtoGen>> Save(
            [FromForm] JobDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<BlackhawkDesign.Data.Models.Job> dataSource,
            IBehaviors<BlackhawkDesign.Data.Models.Job> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<JobDtoGen>> Delete(
            string id,
            IBehaviors<BlackhawkDesign.Data.Models.Job> behaviors,
            IDataSource<BlackhawkDesign.Data.Models.Job> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
