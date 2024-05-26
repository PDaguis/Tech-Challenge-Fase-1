﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase1.Core.Entities
{
    public class DomainException : Exception
    {
        /// <summary>
        ///  Cria somente uma instancia
        /// </summary>
        public DomainException() { }

        /// <summary>
        /// Passa uma mensagem personalizada
        /// </summary>
        /// <param name="message"></param>
        public DomainException(string message) : base(message) { }

        /// <summary>
        /// Passa uma mensagem e uma exception que iniciou anteriormente e queremos retornar ela
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public DomainException(string message, Exception innerException) : base(message, innerException) { }
    }
}
