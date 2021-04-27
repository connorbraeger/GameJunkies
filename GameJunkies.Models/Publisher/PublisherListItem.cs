﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJunkies.Models.Publisher
{
    public class PublisherListItem
    {
        public int? PublisherId { get; set; }
        public string Name { get; set; }
        [Required, DisplayName("Date added to database")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}