using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace market.api.Models
{
    public class Privilege : BaseEntity
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public int Number { get; set; }

        public Privilege() { }

        public Privilege(string name, string Key, int number)
        {
            this.Name = name;
            this.Key = Key;
            this.Number = number;
        }


        public static List<Privilege> GetInitialPrivileges()
        {
            List<Privilege> initialPrivileges = new List<Privilege> {
                new Privilege("İşletme Faaliyetini Durdurma, Faal Hale Getirme", "ChangeCompanyStatusPrivilege", 4),
                new Privilege("Ürün Oluşturma", "CreateProductPrivilege", 5),
                new Privilege("Ürün Silme", "DeleteProductPrivilege", 6),
                new Privilege("Ürün Güncelleme", "UpdateProductPrivilege", 7),
                new Privilege("Ürüne Özellik Ekleme", "AddPropertyToProductPrivilege", 8),
                new Privilege("Üründen Özellik Silme", "DeletePropertyFromProductPrivilege", 9),
                new Privilege("Üründeki Özelliği Değiştirme", "UpdatePropertyPrivilege", 10),
                new Privilege("Ürünleri Arama ve Görüntüleme", "GetAllProductsPrivilege", 11),
                new Privilege("Kategori Oluşturma", "CreateCategoryPrivilege", 12),
                new Privilege("Kategori Silme", "DeleteCategoryPrivilege", 13),
                new Privilege("Kategori Düzenleme", "UpdateCategoryPrivilege", 14),
                new Privilege("Kategorileri Arama ve Görüntüleme", "GetAllCategoriesPrivilege", 15),
                new Privilege("Sipariş Oluşturma", "CreateOrderPrivilege", 16),
                new Privilege("Siparişi Aktif veya Deaktif Etme", "ChangeOrderStatusPrivilege", 17),
                new Privilege("Sipariş Silme", "DeleteOrderPrivilege", 18),
                new Privilege("Siparişe Ürün Ekleme", "AddProductToOrderPrivilege", 19),
                new Privilege("Siparişten Ürün Çıkarma", "DeleteProductFromOrderPrivilege", 20),
                new Privilege("Sipariş Düzenleme", "UpdateOrderPrivilege", 21),
                new Privilege("Siparişleri Arama ve Görüntüleme", "GetAllOrdersPrivilege", 22),
                new Privilege("Sipariş Onaylama", "ConfirmOrderPrivilege", 24),
                new Privilege("Rol Oluşturma", "CreateRolePrivilege", 25),
                new Privilege("Rol Silme", "DeleteRolePrivilege", 26),
                new Privilege("Role Kullanıcı Ekleme", "AddUserToRolePrivilege", 27),
                new Privilege("Rolden Kullanıcı Silme", "DeleteUserFromRolePrivilege", 28),
                new Privilege("Rol ve Rol Ayrıcalıkları Düzenleme", "UpdateRolePrivilege", 29),
                new Privilege("Rolleri Arama ve Görüntüleme", "GetAllRolesPrivilege", 31),
                //new Privilege("Kullanıcının Rollerini Düzenleme", "UpdateUserRolesPrivilege", 34),
                new Privilege("Kullanıcıları Arama ve Görüntüleme", "GetAllUsersPrivilege", 36),
                new Privilege("Müşteri Ekleme", "CreateClientPrivilege", 38),
                new Privilege("Müşteri Silme", "DeleteClientPrivilege", 39),
                new Privilege("Müşteri Düzenleme", "UpdateClientPrivilege", 40),
                new Privilege("Müşterileri Arama ve Görüntüleme", "GetAllClientsPrivilege", 41),
                new Privilege("Müşteri Siparişlerini Arama ve Görüntüleme", "GetClientOrdersPrivilege", 43),
            };
            return initialPrivileges;
        }
    }
}
