﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryRoomWatcher.Entities
{
    public class MemoFileEntity
    {
        public string memo_id { get; set; }
        public string file_dest { get; set; }
        public string file_name { get; set; }
        public DateTime? encoded_at { get; set; }
    }
}
