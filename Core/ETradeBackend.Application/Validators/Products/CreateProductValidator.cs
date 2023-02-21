using ETradeBackend.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator() {
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("Lütfen ürün adını boş geçmeyiniz.")
                .MaximumLength(150)
                .MinimumLength(5)
                .WithMessage("Lütfen ürün adını 5 ile 150 karakter arasında giriniz.");

            RuleFor(p => p.Stock).NotNull().NotEmpty().WithMessage("Lütfen stok bilgisini boş geçmeyiniz.")
                .Must(p => p >= 0).WithMessage("Lütfen stok bilgisini eksi değer girmeyiniz.");

            RuleFor(p => p.Price).NotNull().NotEmpty().WithMessage("Lütfen fiyat bilgisini boş geçmeyiniz.")
               .Must(p => p >= 0).WithMessage("Lütfen fiyat bilgisini eksi değer girmeyiniz.");
        }
    }
}
