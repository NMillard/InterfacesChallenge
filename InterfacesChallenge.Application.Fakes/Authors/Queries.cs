using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfacesChallenge.Application.Interfaces.Authors;
using InterfacesChallenge.Domain;

namespace InterfacesChallenge.Application.Fakes.Authors {
    internal class GetAuthors : IGetAuthors {
        private readonly AuthorRepositoryFake repositoryFake;

        public GetAuthors(AuthorRepositoryFake repositoryFake) {
            this.repositoryFake = repositoryFake;
        }

        public async Task<IEnumerable<Author>> ExecuteAsync() => repositoryFake.Authors;
    }
    
    internal class GetAuthor : IGetAuthor {
        private readonly AuthorRepositoryFake repositoryFake;

        public GetAuthor(AuthorRepositoryFake repositoryFake) {
            this.repositoryFake = repositoryFake;
        }
        
        public async Task<Author?> ExecuteAsync(string penName) => repositoryFake
            .Authors
            .SingleOrDefault(a => a.PenName.Equals(penName));
    }
}