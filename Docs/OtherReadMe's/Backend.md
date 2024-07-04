ASP.NET Core Rest API kullanıldı. 
Docker kullanılmadı.

Teknolojiler: Fluent Validation, Autofac, AutoMapper, JWT, Swashbuckle Swagger, Azure Portal, 

Tasarım Linki : [Acı Sözlük](https://eksisozlukwebapi.azurewebsites.net/api)

# Kadir Yalçın Kodlama
1. Giriş Yap : /api/Auths/login (POST)
2. Yazar Yap : /api/Auths/make-author (POST)
3. Kanalları Getir : /api/Channels/GetChannels (GET)
4. Entryi Filtreye göre getir : /api/Entry/GetEntryByFilter (GET)
5. Entry Güncelle : /api/Entry/UpdateProfileEntry (PUT)
6. Entry Ekle : /api/Entry/CreateEntry (POST)
7. Entry İşlemlerini filtreye göre getir : /api/EntryTransaction/GetEntryTransactionsByFilter (GET)
8. Entry İşlemlerini Güncelle : /api/EntryTransaction/UpdateEntryTransaction (PUT)
9. Entry İşlem İlişkisini Getir : /api/EntryTransactionRelation/GetEntryTransactionRelationByFilter (GET)
10. Entry İşlem ilişkisini oluştur : /api/EntryTransactionRelation/CreateEntryTransactionRelation (POST)
11. Takip Edilen Kanalları Getir : /api/FollowChannels/GetFollowChannelsByFilter (GET)
12. Kanal Takip Et : /api/FollowChannels/FollowChannel (POST)
13. Kanal Takibi Kaldır : /api/FollowChannels/UnfollowChannel (DELETE)
14. Başlıkları Filtreye Göre Getir : /api/Titles/GetTitleByFilter (GET) 
15. Başlıkları Entryleri İle Birlikte Filtreye Göre Getir : /api/Titles/GetTitleByFilterWithEntries (GET)
16. Başlıkları İlk Entrysi İle Birlikte Filtreye Göre Getir : /api/Titles/GetTitlesByFilterWithFirstEntry (GET)
17. Başlık Getirme Durumu İçin Bazı Özel Başlıklarda Farklı Sorgu İşlemleri Uygulanmakta (bugün, gündem, debe, takip, son, kenar, çaylaklar)

# Alper Köşgeroğlu Kodlama
1. Kayıt Ol : /api/Auths/Register (POST)
2. Entryleri Filtreye Göre Getir : /api/Entry/GetEntriesByFilter (GET)
3. Kullanıcı Profilini Filtreye Göre Getir : /api/User/GetUser (GET)
4. Entry Silme : /api/Entry/ProfileEntryRemove (PUT)
