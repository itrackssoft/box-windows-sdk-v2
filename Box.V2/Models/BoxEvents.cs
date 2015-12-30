// <copyright file="BoxEvents.cs" company="itracks" >
//      Copyright (c) itracks All Right Reserved
// </copyright>
// <author>sean.gifford </author>
// <date>12/15/2015</date> 

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Box.V2.Models
{
    /// <summary>
    /// Represents the container in which event queries are returned.
    /// </summary>
    public class BoxEvents
    {
        public const string FieldChunkSize = "chunk_size";
        public const string FieldNextStreamPositon = "next_stream_position";
        public const string FieldEvents = "entries";

        /// <summary>
        /// Gets or sets the number of event records returned.
        /// </summary>
        /// <value>The number of event records returned.</value>
        [JsonProperty(PropertyName = FieldChunkSize)]
        public int ChunkSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the  next position in the event stream that you should request in order to get the next events.
        /// <value>The  next position in the event stream that you should request in order to get the next events</value>
        [JsonProperty(PropertyName = FieldNextStreamPositon)]
        public long NextStreamPositon
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the events that have occurred.
        /// </summary>
        /// <value>The events that have occurred.</value>
        [JsonProperty(PropertyName = FieldEvents)]
        public List<BoxEvent> Events
        {
            get;
            set;
        }
    }
}