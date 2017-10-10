

namespace Infra.Repositories
{
    using AutoMapper;
    using DTO;
    using Infra.Context;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class ConfiguracaoRepository : IRepository
    {

        /// <summary>
        /// Method constructor in here we mapped dto to entitie and reverse by automapper
        /// </summary>
        public ConfiguracaoRepository()
        {

        }

        /// <summary>
        /// to list all objects
        /// </summary>
        public IDTO GetById(int codigo)
        {
            ConfiguracaoDTO obj;
            using (var db = new modelEntities())
            {
                // Display all Blogs from the database 
                var query = from b in db.Configuracao where b.codigo == codigo select b;
                Configuracao Configuracao = query.FirstOrDefault();
                obj = Mapper.Map<Configuracao, ConfiguracaoDTO>(Configuracao);
            }


            return obj;
        }

        /// <summary>
        /// to delete a user from database
        /// </summary>
        /// <param name="id">the id primary key from object</param>
        public void Delete(int codigo)
        {
            try
            {
                ConfiguracaoDTO obj = new ConfiguracaoDTO();
                using (var db = new modelEntities())
                {
                    // Display all Blogs from the database 
                    var query = from b in db.Configuracao where b.codigo == codigo select b;
                    Configuracao Configuracao = query.FirstOrDefault();
                    //Delete it from memory
                    db.Configuracao.Remove(Configuracao);
                    //Save to database\ 
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// to list all objects
        /// </summary>
        public IEnumerable<IDTO> ListAll()
        {
            IEnumerable<IDTO> AllObj = new List<ConfiguracaoDTO>();
                using (var db = new modelEntities())
                {
                    // Display all Configuracaos from the database 
                    var query = from b in db.Configuracao select b;
                    List<Configuracao> list = query.ToList();
                    AllObj = Mapper.Map<List<Configuracao>, List<ConfiguracaoDTO>>(list);

                }


                return AllObj;
            
        }

              

        /// <summary>
        /// to insert a new object in db
        /// </summary>
        /// <param name="obj">a new object in db</param>
        public int Save(IDTO dto)
        {
            int id = 0;
            try
            {
                if (ValidateEntitie(dto))
                {
                    Configuracao Configuracao = Mapper.Map<Configuracao>(ValidateBusiness(dto));

                    using (var db = new modelEntities())
                    {
                        using (var transaction = db.Database.BeginTransaction())
                        {
                            // Display all Configuracaos from the database                        
                            db.Configuracao.Add(Configuracao);
                            id = db.SaveChanges();
                            transaction.Commit();
                        }
                    }
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// to update an object in db
        /// </summary>
        /// <param name="obj">a new object in db</param>
        public int Update(IDTO dto)
        {
            int id = 0;
            try
            {
                if (ValidateEntitie(dto))
                {
                    Configuracao Configuracao = Mapper.Map<Configuracao>(ValidateBusiness(dto));
                    using (var db = new modelEntities())
                    {
                        // Display all Configuracaos from the database                        
                        db.Entry(Configuracao).State = System.Data.Entity.EntityState.Modified;
                        id = db.SaveChanges();

                    }
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// function to validate if this dto is according into business rules
        /// </summary>
        /// <param name="dto">a dto which will be validated</param>
        public bool ValidateEntitie(IDTO dto)
        {
            ConfiguracaoDTO ConfiguracaoDTO = (ConfiguracaoDTO)dto;
            bool validated = false;
            if (string.IsNullOrEmpty(ConfiguracaoDTO.Nome) || string.IsNullOrWhiteSpace(ConfiguracaoDTO.Nome))
            {
                throw new Exception("O campo nome é obrigatório");
            }
            else
            {
                validated = true;
            }
            return validated;
        }

        /// <summary>
        /// function to validate business rules
        /// </summary>
        /// <param name="dto">a dto which will be validated</param>
        public IDTO ValidateBusiness(IDTO dto)
        {
            ConfiguracaoDTO Configuracaodto = (ConfiguracaoDTO)dto;
            //bool validated = false;
            //if (!string.IsNullOrEmpty(Configuracaodto.Nome) &&
            //    !string.IsNullOrWhiteSpace(Configuracaodto.Nome))
            //{
            //    validated = true;
            //}
            return Configuracaodto;
        }
    }
}
