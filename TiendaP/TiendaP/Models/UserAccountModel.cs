﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaP.Models
{
    public class UserAccountModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Tipo { get; set; }
        public byte[] ProfilePicture { get; set; }

    }
}
