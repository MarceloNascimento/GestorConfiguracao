﻿namespace DTO
{
   public class ClientDTO : IDTO
    {
        /// <summary>
        /// Código of client
        /// </summary>        
        public int Codigo { get; set; }
        /// <summary>
        /// Nome of client
        /// </summary> 
        public string Nome { get; set; }
        /// <summary>
        /// tipo of client "fisica / juridica"
        /// </summary> 
        public string Tipo { get; set; }
        /// <summary>
        /// CPF of client
        /// </summary> 
        public string CPF { get; set; }
        /// <summary>
        /// CNPJ of client
        /// </summary> 
        public string CNPJ { get; set; }
        /// <summary>
        /// telephone number from client
        /// </summary> 
        public string Telefone { get; set; }
    }
}
