﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class User
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
