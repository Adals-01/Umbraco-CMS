﻿using System;
using Umbraco.Core;
using Umbraco.Core.Cache;
using Umbraco.Core.Configuration;
using Umbraco.Core.Logging;
using Umbraco.Core.Mapping;
using Umbraco.Core.Persistence;
using Umbraco.Core.Services;
using Umbraco.Core.Strings;
using Umbraco.Web.Composing;
using Umbraco.Web.WebApi;
using Umbraco.Web.WebApi.Filters;

namespace Umbraco.Web.Editors
{
    /// <summary>
    /// An abstract API controller that only supports JSON and all requests must contain the correct csrf header
    /// </summary>
    /// <remarks>
    /// Inheriting from this controller means that ALL of your methods are JSON methods that are called by Angular,
    /// methods that are not called by Angular or don't contain a valid csrf header will NOT work.
    /// </remarks>
    [ValidateAngularAntiForgeryToken]
    [AngularJsonOnlyConfiguration]
    public abstract class UmbracoAuthorizedJsonController : UmbracoAuthorizedApiController
    {
        protected UmbracoAuthorizedJsonController()
        {
            ShortStringHelper = Current.ShortStringHelper;
        }

        protected UmbracoAuthorizedJsonController(IGlobalSettings globalSettings, IUmbracoContextAccessor umbracoContextAccessor, ISqlContext sqlContext, ServiceContext services, AppCaches appCaches, IProfilingLogger logger, IRuntimeState runtimeState, UmbracoHelper umbracoHelper, IShortStringHelper shortStringHelper, UmbracoMapper umbracoMapper)
            : base(globalSettings, umbracoContextAccessor, sqlContext, services, appCaches, logger, runtimeState, umbracoHelper, umbracoMapper)
        {
            ShortStringHelper = shortStringHelper ?? throw new ArgumentNullException(nameof(shortStringHelper));
        }

        protected IShortStringHelper ShortStringHelper { get; }
    }
}
