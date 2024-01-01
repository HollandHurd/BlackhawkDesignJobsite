
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
    [Route("api/Application")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class ApplicationController
        : BaseApiController<BlackhawkDesign.Data.Models.Application, ApplicationDtoGen, BlackhawkDesign.Data.AppDbContext>
    {
        public ApplicationController(CrudContext<BlackhawkDesign.Data.AppDbContext> context) : base(context)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<BlackhawkDesign.Data.Models.Application>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ApplicationDtoGen>> Get(
            string id,
            DataSourceParameters parameters,
            IDataSource<BlackhawkDesign.Data.Models.Application> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<ApplicationDtoGen>> List(
            ListParameters parameters,
            IDataSource<BlackhawkDesign.Data.Models.Application> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<BlackhawkDesign.Data.Models.Application> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<ApplicationDtoGen>> Save(
            [FromForm] ApplicationDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<BlackhawkDesign.Data.Models.Application> dataSource,
            IBehaviors<BlackhawkDesign.Data.Models.Application> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ApplicationDtoGen>> Delete(
            string id,
            IBehaviors<BlackhawkDesign.Data.Models.Application> behaviors,
            IDataSource<BlackhawkDesign.Data.Models.Application> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);

        // Methods from data class exposed through API Controller.

        /// <summary>
        /// Method: UploadAttachment
        /// </summary>
        [HttpPost("UploadAttachment")]
        [Authorize]
        public virtual async Task<ItemResult> UploadAttachment(
            [FromServices] IDataSourceFactory dataSourceFactory,
            [FromForm(Name = "id")] string id,
            Microsoft.AspNetCore.Http.IFormFile file)
        {
            var dataSource = dataSourceFactory.GetDataSource<BlackhawkDesign.Data.Models.Application, BlackhawkDesign.Data.Models.Application>("Default");
            var (itemResult, _) = await dataSource.GetItemAsync(id, new DataSourceParameters());
            if (!itemResult.WasSuccessful)
            {
                return new ItemResult(itemResult);
            }
            var item = itemResult.Object;
            var _params = new
            {
                file = file == null ? null : new IntelliTect.Coalesce.Models.File { Name = file.FileName, ContentType = file.ContentType, Length = file.Length, Content = file.OpenReadStream() }
            };

            if (Context.Options.ValidateAttributesForMethods)
            {
                var _validationResult = ItemResult.FromParameterValidation(
                    GeneratedForClassViewModel!.MethodByName("UploadAttachment"), _params, HttpContext.RequestServices);
                if (!_validationResult.WasSuccessful) return _validationResult;
            }

            await item.UploadAttachment(
                Db,
                _params.file
            );
            await Db.SaveChangesAsync();
            var _result = new ItemResult();
            return _result;
        }

        /// <summary>
        /// Method: DownloadAttachment
        /// </summary>
        [HttpGet("DownloadAttachment")]
        [Authorize]
        public virtual async Task<ActionResult<ItemResult<IntelliTect.Coalesce.Models.IFile>>> DownloadAttachment(
            [FromServices] IDataSourceFactory dataSourceFactory,
            string id,
            byte[] etag)
        {
            var dataSource = dataSourceFactory.GetDataSource<BlackhawkDesign.Data.Models.Application, BlackhawkDesign.Data.Models.Application>("Default");
            var (itemResult, _) = await dataSource.GetItemAsync(id, new DataSourceParameters());
            if (!itemResult.WasSuccessful)
            {
                return new ItemResult<IntelliTect.Coalesce.Models.IFile>(itemResult);
            }
            var item = itemResult.Object;

            var _currentVaryValue = item.AttachmentHash;
            if (_currentVaryValue != default)
            {
                var _expectedEtagHeader = new Microsoft.Net.Http.Headers.EntityTagHeaderValue('"' + Microsoft.AspNetCore.WebUtilities.Base64UrlTextEncoder.Encode(_currentVaryValue) + '"');
                var _cacheControlHeader = new Microsoft.Net.Http.Headers.CacheControlHeaderValue { Private = true, MaxAge = TimeSpan.Zero };
                if (etag != default && _currentVaryValue.SequenceEqual(etag))
                {
                    _cacheControlHeader.MaxAge = TimeSpan.FromDays(30);
                }
                Response.GetTypedHeaders().CacheControl = _cacheControlHeader;
                Response.GetTypedHeaders().ETag = _expectedEtagHeader;
                if (Request.GetTypedHeaders().IfNoneMatch.Any(value => value.Compare(_expectedEtagHeader, true)))
                {
                    return StatusCode(StatusCodes.Status304NotModified);
                }
            }

            var _methodResult = item.DownloadAttachment(
                Db
            );
            await Db.SaveChangesAsync();
            if (_methodResult != null)
            {
                string _contentType = _methodResult.ContentType;
                if (string.IsNullOrWhiteSpace(_contentType) && (
                    string.IsNullOrWhiteSpace(_methodResult.Name) ||
                    !(new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider().TryGetContentType(_methodResult.Name, out _contentType))
                ))
                {
                    _contentType = "application/octet-stream";
                }
                return File(_methodResult.Content, _contentType, _methodResult.Name, !(_methodResult.Content is System.IO.MemoryStream));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
