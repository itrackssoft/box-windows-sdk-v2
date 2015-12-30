// <copyright file="BoxEvent.cs" company="itracks" >
//      Copyright (c) itracks All Right Reserved
// </copyright>
// <author>sean.gifford </author>
// <date>12/15/2015</date> 

using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Box.V2.Models
{
    /// <summary>
    /// Represents an event as returned by the Box v2 API
    /// </summary>
    public class BoxEvent
    {
        public const string FieldEventId = "event_id";
        public const string FieldCreatedBy = "created_by";
        public const string FieldCreatedAt = "created_at";
        public const string FieldRecordedAt = "recorded_at";
        public const string FieldEventType = "event_type";
        public const string FieldSessionId = "session_id";
        public const string FieldEventSource = "source";
        private const string FieldType = "type";

        /// <summary>
        /// Gets or sets the type.  Should be "event"
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty(PropertyName = FieldType)]
        public string Type
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the id of the event, used for de-duplication purposes
        /// </summary>
        /// <value>The id of the event, used for de-duplication purposes</value>
        [JsonProperty(PropertyName = FieldEventId)]
        public string EventId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user that performed the action
        /// </summary>
        /// <value>The user that performed the action</value>
        [JsonProperty(PropertyName = FieldCreatedBy)]
        public BoxUser CreatedBy
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the datetime that the action occurred.
        /// </summary>
        /// <value>The datetime that the action occurred.</value>
        [JsonProperty(PropertyName = FieldCreatedAt)]
        public DateTimeOffset CreatedAt
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the datetime that the action was recorded.
        /// </summary>
        /// <value>The datetime that the action was recorded.</value>
        [JsonProperty(PropertyName = FieldRecordedAt)]
        public DateTimeOffset RecordedAt
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the event.
        /// </summary>
        /// <value>The type of the event.</value>
        [JsonProperty(PropertyName = FieldEventType)]
        [JsonConverter(typeof(StringEnumConverter))]
        public BoxUserEventType EventType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the session of the user that performed the action
        /// </summary>
        /// <value>The session of the user that performed the action</value>
        [JsonProperty(PropertyName = FieldSessionId)]
        public string SessionId
        {
            get;
            set;
        }

        /// <summary>
        /// <para>Gets or sets the object that was modified.</para>
        /// <para>See Object definitions for appropriate object: file, folder, comment, etc.</para>
        /// <para>Not all events have a source object.</para>
        /// </summary>
        /// <value>The object that was modified, if appropriate.  May be NULL</value>
        [JsonProperty(PropertyName = FieldEventSource)]
        public BoxEntity EventSource
        {
            get;
            set;
        }
    }
}