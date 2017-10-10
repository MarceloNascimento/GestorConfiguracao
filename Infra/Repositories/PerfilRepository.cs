

namespace Infra.Repositories
{
    using AutoMapper;
    using DTO;
    using Infra.Context;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class PerfilRepository : IRepository
    {

        /// <summary>
        /// Method constructor in here we mapped dto to entitie and reverse by automapper
        /// </summary>
        public PerfilRepository()
        {

        }

        /// <summary>
        /// to list all objects
        /// </summary>
        public IDTO GetById(int codigo)
        {
            PerfilDTO obj;
            using (var db = new modelEntities())
            {
                // Display all Blogs from the database 
                var query = from b in db.Perfil where b.codigo == codigo select b;
                Perfil Perfil = query.FirstOrDefault();
                obj = Mapper.Map<Perfil, PerfilDTO>(Perfil);
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
                PerfilDTO obj = new PerfilDTO();
                using (var db = new modelEntities())
                {
                    // Display all Blogs from the database 
                    var query = from b in db.Perfil where b.codigo == codigo select b;
                    Perfil Perfil = query.FirstOrDefault();
                    //Delete it from memory
                    db.Perfil.Remove(Perfil);
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
            IEnumerable<IDTO> AllObj = new List<PerfilDTO>();
                using (var db = new modelEntities())
                {
                    // Display all Perfils from the database 
                    var query = from b in db.Perfil select b;
                    List<Perfil> list = query.ToList();
                    AllObj = Mapper.Map<List<Perfil>, List<PerfilDTO>>(list);

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
                    Perfil Perfil = Mapper.Map<Perfil>(ValidateBusiness(dto));

                    using (var db = new modelEntities())
                    {
                        using (var transaction = db.Database.BeginTransaction())
                        {
                            // Display all Perfils from the database                        
                            db.Perfil.Add(Perfil);
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
                    Perfil Perfil = Mapper.Map<Perfil>(ValidateBusiness(dto));
                    using (var db = new modelEntities())
                    {
                        // Display all Perfils from the database                        
                        db.Entry(Perfil).State = System.Data.Entity.EntityState.Modified;
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
            PerfilDTO PerfilDTO = (PerfilDTO)dto;
            bool validated = false;
            if (string.IsNullOrEmpty(PerfilDTO.nome) || string.IsNullOrWhiteSpace(PerfilDTO.nome))
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
            PerfilDTO Perfildto = (PerfilDTO)dto;
            bool validated = false;
            if (!string.IsNullOrEmpty(Perfildto.tipo) &&
                !string.IsNullOrWhiteSpace(Perfildto.tipo))
            {
                if (Perfildto.tipo == "Física")
                {
                    Perfildto.CNPJ = "";
                }
                else if(Perfildto.tipo != "Física")
                {
                    Perfildto.CPF = "";
                }

            }
            return Perfildto;
        }
    }
}
