﻿using FlowerShopBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace FlowerShopBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel
    {
        [DataMember]
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }

        [DataMember]
        [Column(title: "Клиент", width: 150)]
        public string ClientFIO { get; set; }

        [DataMember]
        [Column(title: "Логин", width: 100)]
        public string Email { get; set; }

        [DataMember]
        [Column(title: "Пароль", width: 100)]
        public string Password { get; set; }
    }
}