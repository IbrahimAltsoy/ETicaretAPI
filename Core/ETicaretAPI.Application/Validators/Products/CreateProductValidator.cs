using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductValidator: AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen ürün adını boş geçmeyiniz.")
                .MaximumLength(150)
                .MinimumLength(2)
                    .WithMessage("Lütfen ürün ad kısmı 1 karakterden çok 150 karakterden az giriniz.");


            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen stok bilgisini giriniz.")
                .Must(c => c >= 0)
                    .WithMessage("stok bilgisi negatif olamaz");
            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("lütfen fiyat bilgisini giriniz.")
                .Must(p => p >=0)
                    .WithMessage("Fiyat bilgisi negatif olamaz.");
                
        }
    }
}
