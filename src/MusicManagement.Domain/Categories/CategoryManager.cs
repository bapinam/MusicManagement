using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace MusicManagement.Categories
{
    public class CategoryManager : DomainService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> CreateAsync(
            [NotNull] string name,
            [CanBeNull] string description = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingAuthor = await _categoryRepository.FindByNameAsync(name);
            if (existingAuthor != null)
            {
                throw new CategoryAlreadyExistsException(name);
            }

            return new Category(
                GuidGenerator.Create(),
                name,
                description);
        }

        public async Task ChangeNameAsync(
            [NotNull] Category category,
            [NotNull] string newName)
        {
            Check.NotNull(category, nameof(category));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingAuthor = await _categoryRepository.FindByNameAsync(newName);
            if (existingAuthor != null && existingAuthor.Id != category.Id)
            {
                throw new CategoryAlreadyExistsException(newName);
            }

            category.ChangeName(newName);
        }
    }
}