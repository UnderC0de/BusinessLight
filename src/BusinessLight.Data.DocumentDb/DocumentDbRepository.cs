namespace BusinessLight.Data.DocumentDb
{
    using System;
    using System.CodeDom;
    using System.Configuration;
    using System.Linq;
    using System.Threading.Tasks;

    using BusinessLight.Data.Specifications;
    using BusinessLight.Domain;

    using Microsoft.Azure.Documents;
    using Microsoft.Azure.Documents.Client;

    public class DocumentDbRepository : IRepository
    {
        private readonly DocumentClient client;
        private readonly string databaseId;
        private readonly string collectionId;
        private readonly string endpoint;
        private readonly string authKey;

        public DocumentDbRepository()
        {
            this.databaseId = ConfigurationManager.AppSettings["database"];
            this.collectionId = ConfigurationManager.AppSettings["collection"];
            this.endpoint = ConfigurationManager.AppSettings["endpoint"];
            this.authKey = ConfigurationManager.AppSettings["authKey"];

            if (this.databaseId == null)
            {
                throw new ArgumentNullException(nameof(this.databaseId), "Missing appsetting databaseId");
            }
            
            if (this.collectionId == null)
            {
                throw new ArgumentNullException(nameof(this.collectionId), "Missing appsetting collectionId");
            }
            
            if (this.endpoint == null)
            {
                throw new ArgumentNullException(nameof(this.endpoint), "Missing appsetting endpoint");
            }
            
            if (this.authKey == null)
            {
                throw new ArgumentNullException(nameof(this.authKey), "Missing appsetting authKey");
            }

            this.client = new DocumentClient(new Uri(this.endpoint), this.authKey);
        }

        public DocumentDbRepository(string databaseId, string collectionId, string endpoint, string authKey)
        {
            if (databaseId == null)
            {
                throw new ArgumentNullException(nameof(databaseId));
            }

            if (collectionId == null)
            {
                throw new ArgumentNullException(nameof(collectionId));
            }

            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }

            if (authKey == null)
            {
                throw new ArgumentNullException(nameof(authKey));
            }

            this.databaseId = databaseId;
            this.collectionId = collectionId;
            this.endpoint = endpoint;
            this.authKey = authKey;
            this.client = new DocumentClient(new Uri(this.endpoint), this.authKey);
        }
        
        public async Task AddAsync<T>(T entity)
            where T : Entity
        {
            await this.client.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(this.databaseId, this.collectionId),
                entity);
        }

        public async Task UpdateAsync<T>(T entity)
            where T : Entity
        {
            await this.client.ReplaceDocumentAsync(
                UriFactory.CreateDocumentUri(this.databaseId, this.collectionId, entity.Id.ToString()),
                entity);
        }

        public async Task AddOrUpdateAsync<T>(T entity)
            where T : Entity
        {
            var exists = await this.GetByIdAsync<T>(entity.Id) != null;
            if (exists)
            {
                await UpdateAsync(entity);
            }
            else
            {
                await AddAsync(entity);
            }
        }

        public async Task RemoveAsync<T>(T entity)
            where T : Entity
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> QueryAsync<T>()
            where T : Entity
        {
            IQueryable<T> result = this.client.CreateDocumentQuery<T>(
                UriFactory.CreateDocumentCollectionUri(this.databaseId, this.collectionId),
                new FeedOptions { MaxItemCount = -1 });
            return Task.FromResult(result);
        }

        public async Task<IQueryable<T>> IsSatisfiedByAsync<T>(ISpecification<T> specification)
            where T : Entity
        {
            return (await QueryAsync<T>()).Where(specification.GetSpecificationExpression());
        }

        public async Task<IOrderedQueryable<T>> IsSatisfiedByAsync<T>(ISortedSpecification<T> specification)
            where T : Entity
        {
            return specification.GetSortingExpression()((await QueryAsync<T>()).Where(specification.GetSpecificationExpression()));
        }

        public async Task<T> GetByIdAsync<T>(Guid id)
            where T : Entity
        {
            try
            {
                var document = await this.client.ReadDocumentAsync(UriFactory.CreateDocumentUri(this.databaseId, this.collectionId, id.ToString()));
                return (T)(dynamic)document;
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }

                throw;
            }
        }

        public void Dispose()
        {
            this.client.Dispose();
        }
    }
}
