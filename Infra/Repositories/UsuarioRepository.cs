

namespace Infra.Repositories
{
    using AutoMapper;
    using DTO;
    using Infra.Context;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class UsuarioRepository : IRepository
    {

        /// <summary>
        /// Method constructor in here we mapped dto to entitie and reverse by automapper
        /// </summary>
        public UsuarioRepository()
        {

        }

        /// <summary>
        /// to list all objects
        /// </summary>
        public IDTO GetById(int codigo)
        {
            UsuarioDTO obj;
            using (var db = new modelEntities())
            {
                // Display all Blogs from the database 
                var query = from b in db.Usuarios where b.codigo == codigo select b;
                Usuarios usuario = query.FirstOrDefault();
                obj = Mapper.Map<Usuarios, UsuarioDTO>(usuario);
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
                UsuarioDTO obj = new UsuarioDTO();
                using (var db = new modelEntities())
                {
                    // Display all Blogs from the database 
                    var query = from b in db.Usuarios where b.codigo == codigo select b;
                    Usuarios Usuario = query.FirstOrDefault();
                    //Delete it from memory
                    db.Usuarios.Remove(Usuario);
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
            IEnumerable<IDTO> AllObj = new List<UsuarioDTO>();
                using (var db = new modelEntities())
                {
                    // Display all Usuarios from the database 
                    var query = from b in db.Usuarios select b;
                    List<Usuarios> list = query.ToList();
                    AllObj = Mapper.Map<List<Usuarios>, List<UsuarioDTO>>(list);

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
                    Usuarios Usuario = Mapper.Map<Usuarios>(ValidateBusiness(dto));

                    using (var db = new modelEntities())
                    {
                        using (var transaction = db.Database.BeginTransaction())
                        {
                            // Display all Usuarios from the database                        
                            db.Usuarios.Add(Usuario);
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
                    Usuarios Usuario = Mapper.Map<Usuarios>(ValidateBusiness(dto));
                    using (var db = new modelEntities())
                    {
                        // Display all Usuarios from the database                        
                        db.Entry(Usuario).State = System.Data.Entity.EntityState.Modified;
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
            UsuarioDTO UsuarioDTO = (UsuarioDTO)dto;
            bool validated = false;
            if (string.IsNullOrEmpty(UsuarioDTO.Nome) || string.IsNullOrWhiteSpace(UsuarioDTO.Nome))
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
            UsuarioDTO Usuariodto = (UsuarioDTO)dto;
            //bool validated = false;
            //if (!string.IsNullOrEmpty(Usuariodto.Nome) &&
            //    !string.IsNullOrWhiteSpace(Usuariodto.Nome))
            //{
            //    validated = true;
            //}
            return Usuariodto;
        }
    }
}
