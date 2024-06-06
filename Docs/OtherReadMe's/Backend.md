ASP.NET Core Rest API kullanıldı. 
Docker kullanılmadı.

Teknolojiler: Fluent Validation, Autofac, AutoMapper, JWT, Swashbuckle Swagger, Azure Portal, 

Tasarım Linki : [Acı Sözlük](https://eksisozlukwebapi.azurewebsites.net/api)

# Kadir Yalçın Kodlama
1. Giriş Yap : /api/Auths/login (POST)
2. Yazar Yap : /api/Auths/make-author (POST)
3. Kanalları Getir : /api/Channels/GetChannels (GET)
4. Entryleri Filtreye göre getir : /api/Entry/GetEntriesByFilter (GET)
5. Entryi Filtreye göre getir : /api/Entry/GetEntryByFilter (GET)
6. Entry Güncelle : /api/Entry/UpdateProfileEntry (PUT)
7. Entry Ekle : /api/Entry/CreateEntry (POST)
8. Entry İşlemlerini filtreye göre getir : /api/EntryTransaction/GetEntryTransactionsByFilter (GET)
9. Entry İşlemlerini Güncelle : /api/EntryTransaction/UpdateEntryTransaction (PUT)
10. Entry İşlem İlişkisini Getir : /api/EntryTransactionRelation/GetEntryTransactionRelationByFilter (GET)
11. Entry İşlem ilişkisini oluştur : /api/EntryTransactionRelation/CreateEntryTransactionRelation (POST)
12. Takip Edilen Kanalları Getir : /api/FollowChannels/GetFollowChannelsByFilter (GET)
13. Kanal Takip Et : /api/FollowChannels/FollowChannel (POST)
14. Kanal Takibi Kaldır : /api/FollowChannels/UnfollowChannel (DELETE)
15. Başlıkları Filtreye Göre Getir : /api/Titles/GetTitleByFilter (GET) 
16. Başlıkları Entryleri İle Birlikte Filtreye Göre Getir : /api/Titles/GetTitleByFilterWithEntries (GET)
17. Başlıkları İlk Entrysi İle Birlikte Filtreye Göre Getir : /api/Titles/GetTitlesByFilterWithFirstEntry (GET)
18. Başlık Getirme Durumu İçin Bazı Özel Başlıklarda Farklı Sorgu İşlemleri Uygulanmakta (bugün, gündem, debe, takip, son, kenar, çaylaklar)
