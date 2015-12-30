// <copyright file="BoxEventsManager.cs" company="itracks" >
//      Copyright (c) itracks All Right Reserved
// </copyright>
// <author>sean.gifford </author>
// <date>12/15/2015</date> 
 
using System;
using System.Linq;
using System.Threading.Tasks;
using Box.V2.Auth;
using Box.V2.Config;
using Box.V2.Converter;
using Box.V2.Extensions;
using Box.V2.Models;
using Box.V2.Services;

namespace Box.V2.Managers
{
    /// <summary>
    /// <para>The manager that represents event endpoints</para>
    /// <para>Currently, not a complete representation of all event endpoints</para>
    /// <para>Implements functions necessary for simple polling, does not support long polling, or web hooks</para>
    /// </summary>
    public class BoxEventsManager : BoxResourceManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoxEventsManager" /> class.
        /// </summary>
        /// <param name="config">The config.</param>
        /// <param name="service">The service.</param>
        /// <param name="converter">The converter.</param>
        /// <param name="auth">The auth.</param>
        /// <param name="asUser">As user.</param>
        public BoxEventsManager(IBoxConfig config, IBoxService service, IBoxConverter converter, IAuthRepository auth, string asUser = null) : base(config, service, converter, auth, asUser)
        {
        }

        /// <summary>
        /// Gets the current stream position.
        /// </summary>
        /// <returns>
        /// The current stream position.
        /// </returns>
        public async Task<long> GetCurrentStreamPositionAsync()
        {
            BoxRequest request = new BoxRequest(this._config.EventsEndpointUri).Param(Constants.RequestParameters.StreamPosition, Constants.RequestParameters.NowStreamPosition);

            IBoxResponse<BoxEvents> response = await this.ToResponseAsync<BoxEvents>(request).ConfigureAwait(false);

            return response.ResponseObject.NextStreamPositon;
        }

        /// <summary>
        /// Gets the events that have occurred since the provided stream position.
        /// </summary>
        /// <param name="streamPosition">
        /// <para>Optional.  The stream position after which events should be returned.  Default is "0" meaning "all".</para>
        /// <para>The current stream position can be found with <see cref="GetcurrentStreamPositionAsync"/></para>
        /// </param>
        /// <param name="filter">
        /// Optional.  The types of events to include in the query.  Default is <see cref="BoxEventFilter.All"/>
        /// </param>
        /// <param name="limit">
        /// <para>Optional  The maximum number of events to limit the results count to.  Default is 100.</para>
        /// <para>Must be a value between <see cref="Constants.MinStreamLimit"/> and <see cref="Constants.MaxStreamLimit"/></para>
        /// </param>
        /// <returns>
        /// The events that have occurred since the provided stream position.
        /// </returns>
        public async Task<BoxEvents> GetEventsSinceAsync(long streamPosition = 0, BoxEventFilter filter = Constants.DefaultEventFilter, int limit = Constants.DefaultEventLimit)
        {
            if (limit < Constants.MinStreamLimit || limit > Constants.MaxStreamLimit)
            {
                throw new ArgumentOutOfRangeException("limit", string.Format("limit must be within the range {0} <= limit <= {1}", Constants.MinStreamLimit, Constants.MaxStreamLimit));
            }

            BoxRequest request = new BoxRequest(this._config.EventsEndpointUri);

            // only add params if not default
            if (streamPosition > 0)
            {
                request = request.Param(Constants.RequestParameters.StreamPosition, streamPosition.ToString());
            }

            // convert the enum to the expected JSON key
            if (filter != Constants.DefaultEventFilter)
            {
                string filterValue = "all";
                switch( filter)
                {
                    case BoxEventFilter.FolderChanges:
                        filterValue = "changes";
                        break;
                    case BoxEventFilter.SyncedFolderChanges:
                        filterValue = "sync";
                        break;               
                }
                
                request.Param(Constants.RequestParameters.StreamType, filterValue);
            }

            if (limit != Constants.DefaultEventLimit)
            {
                request = request.Param(Constants.RequestParameters.StreamLimit, limit.ToString());
            }

            IBoxResponse<BoxEvents> response = await this.ToResponseAsync<BoxEvents>(request).ConfigureAwait(false);

            return response.ResponseObject;
        }
    }
}
