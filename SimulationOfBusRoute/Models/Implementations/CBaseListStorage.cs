using System;
using SimulationOfBusRoute.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;


namespace SimulationOfBusRoute.Models.Implementations
{
    public abstract class CBaseListStorage<T>: IBaseStorage<T>
                                                where T : IBaseModel
    {
        /// <summary>
        /// The public event occurs when a state of the object was changed.
        /// All methods of the class generate this event except the Find- group of them.
        /// </summary>

        public event Action OnChanged;

        protected List<T> mEntitiesList;
        
        protected CBaseListStorage()
        {
            mEntitiesList = new List<T>();
        }

        #region Methods

        public virtual void Dispose()
        {
            mEntitiesList.Clear();
        }
       
        /// <summary>
        /// Method places a new entity into a memory. If the one already exists, method does nothing.
        /// </summary>
        /// <param name="entity">Insertion entity</param>

        public virtual void Insert(T entity)
        {
            if (mEntitiesList.Contains(entity))
            {
                return;
            }

            int currNumOfEntities = mEntitiesList.Count;

            mEntitiesList.Add(entity);

            //updating of entity's id
            entity.ID = currNumOfEntities;

            _onChanged();
        }

        /// <summary>
        /// Method places a new entity into a memory after specified entity. If the one already exists, method does nothing.
        /// Method throws exceptions for invalid specified entities.
        /// </summary>
        /// <param name="pointer">Specified entity</param>
        /// <param name="entity">Insertion entity</param>

        public virtual void InsertAfter(T pointer, T entity)
        {
            if (pointer == null || !mEntitiesList.Contains(pointer)) //there is no specified entity
            {
                Insert(entity);

                return;
            }

            int newID = pointer.ID + 1;

            mEntitiesList.Insert(newID, entity);

            //entities' id should be recomputed from the new one to end of the list
            _recomputeEntitiesId(mEntitiesList, newID, mEntitiesList.Count);

            _onChanged();
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
            {                
                return;
            }

            mEntitiesList[entity.ID] = entity;
            
            _onChanged();
        }

        /// <summary>
        /// Method removes a specified entity from memory.
        /// </summary>
        /// <param name="entity">An entity, which should be deleted</param>

        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity", "Method's parameter cannot equal to null");
            }

            if (!mEntitiesList.Contains(entity))
            {
                throw new ArgumentOutOfRangeException("entity", "There is no specified entity in the list");
            }

            int currEntityId = entity.ID;

            mEntitiesList.Remove(entity);

            _recomputeEntitiesId(mEntitiesList, currEntityId, mEntitiesList.Count);

            _onChanged();
        }

        public virtual void DeleteAll()
        {
            if (mEntitiesList.Count == 0)
            {
                return;
            }

            mEntitiesList.Clear();

            _onChanged();
        }

        /// <summary>
        /// Method returns an entity by its identifier.
        /// </summary>
        /// <param name="id">Identifier of an entity</param>
        /// <returns>An entity, which ID member equals to the specified one.</returns>

        public virtual T GetById(int id)
        {
            if (id < 0)
            {
                return default(T);
            }

            return mEntitiesList[id];
        }

        /// <summary>
        /// Method returns all entities, which store in a memory.
        /// </summary>
        /// <returns>A list which contains all the entities' data</returns>

        public virtual List<T> GetAll()
        {
            return mEntitiesList;
        }

        /// <summary>
        /// Method returns an entity by its specification. If there are a few entities satisfy the specification
        /// method returns the first.
        /// </summary>
        /// <param name="specification">Specification of an entity.</param>
        /// <returns>An entity is corresponding to specification</returns>

        public virtual T GetBySpecification(ISpecification<T> specification)
        {
            return mEntitiesList.AsQueryable().Where(specification.ToExpression()).FirstOrDefault();
        }

        /// <summary>
        /// Method returns all entities which satisfy the specification.
        /// </summary>
        /// <param name="specification">Specification of an entity.</param>
        /// <returns>List of entities</returns>

        public virtual List<T> GetAllBySpecification(ISpecification<T> specification)
        {
            return mEntitiesList.AsQueryable().Where(specification.ToExpression()).ToList();
        }
        
        /// <summary>
        /// Method recomputes identifiers of entities in specified range.
        /// </summary>
        /// <param name="entities">A list of entities, which should be recomputed</param>
        /// <param name="startIndex">Position of a first entity, which will be recomputed</param>
        /// <param name="finishIndex">Position of a last entity, which should be recomputed</param>
      
        protected void _recomputeEntitiesId(List<T> entities, int startIndex, int finishIndex)
        {
            int last = finishIndex;

            for (int id = startIndex; id < last; id++)
            {
                entities[id].ID = id;
            }
        }

        protected void _onChanged()
        {
            if (OnChanged != null)
            {
                OnChanged();
            }
        }

        #endregion
    }
}
