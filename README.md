## Sprendžiamo uždavinio aprašymas

### Sistemos paskirtis

Kuriama sistema leis palengvinti turimų stalo žaidimų pardavimą arba keitimąsi su kitais stalo žaidimų mėgėjais. 
Sistema leidžia administratoriui pridėti stalo žaidimus prie sistemos. Esamiems žaidimams sistemoje prisijungę naudotojai gali patalpinti skelbimus, kuriuose aprašomas parduodamas stalo žaidimas (pateikiamas turimo žaidimo būklės įvertinimas, nuotraukos). Prie skelbimo galima nurodyti, žaidimą siekiama parduoti ar išsikeisti į kitą. Jei stalo žaidimą norima iškeisti, skelbime papildomai pateikiama informacija apie norimą gauti žaidimą. Taip pat pateikiama ir pardavėjo kontaktinė informacija (telefono numeris ir/arba elektroninio pašto adresas). Kiti prisiregistravę sistemos naudotojai gali palikti komentarus apie skelbimą. Sistemos naudotojai administratoriui gali pateikti užklausas pridėti daugiau stalo žaidimų prie sistemos jei siekiama kurti skelbimą žaidimui kurio nėra sistemoje.  
Sistemos ***naudotojas gali būti trijų tipų: svečias, prisijungęs naudotojas bei administratorius.*** Atitinkamai pagal naudotoją tipą, leidžiama atlikti skirtingas funkcijas.  
***Objektai: Stalo žaidimas – Skelbimas – Skelbimo komentaras.***  

### Funkciniai reikalavimai

Neprisijungęs naudotojas gali:  
1. Prisiregistruoti prie sistemos;  
2. Prisijungti prie sistemos;  
3. Matyti žaidimus;  
4. Matyti skelbimus.   

Prisijungęs naudotojas gali:  
1. Matyti žaidimus;  
2. Matyti skelbimus;  
3. Atsijungti nuo sistemos;  
4. Sukurti skelbimą;  
5. Ištrinti savo pateiktus skelbimus;  
6. Redaguoti savo pateiktus skelbimus;  
7. Pateikti atsiliepimą apie kito naudotojo skelbimą;  
8. Pateikti informaciją apie žaidimą, į kurį norima iškeisti turimą žaidimą;  
9. Pateikti užklausą administratoriui, kad būtų pridėtas naujas žaidimas sistemoje.  

Administratorius gali:  
1. Peržiūrėti žaidimus;  
2. Peržiūrėti skelbimus;  
3. Šalinti paskyras iš sistemos;  
4. Šalinti skelbimus iš sistemos;  
5. Redaguoti skelbimus;  
6. Peržiūrėti žaidimo pridėjimo užklausas;  
7. Pridėti žaidimus prie sistemos;  
8. Šalinti žaidimus iš sistemos;  
9. Redaguoti žaidimų informaciją.  

## Pasirinktų technologijų aprašymas

- Kliento dalies kodas (angl. front-end) kuriamas naudojantis „Svelte“
- Serverio dalies kodas (angl. back-end) kuriamas naudojant „.NET Core 6.0“.
-	Duomenų bazė – „MySQL“.  

„Svelte“ – atvirojo kodo priekinės dalies kompiliatorius, leidžiantis kurti sparčiai veikiančią grafinę naudotojo sąsają naudojant HTML ir JavaScript.  
„.NET Core“ – yra nemokama ir atviro kodo valdoma kompiuterinės programinės įrangos sistema, skirta „Windows“, „Linux“ ir „macOS“ operacinėms sistemoms. Leidžia kurti serverio pusės kodą naudojant C# programavimo kalbą.  
MySQL – viena iš reliacinių duomenų bazių valdymo sistemų, palaikanti daugelį naudotojų, dirbanti SQL kalbos pagrindu.

## Sistemos architektūra

Sistemos architektūrai aiškinti pateikiama UML diegimo diagrama (žr. 1 pav.). Serveris (šiuo atveju kompiuteryje sukurtas serveris) komunikuoja su kitais kompiuteriais naudojant HTTPS protokolą. Sistema galima naudotis ją atidarius per pasirinktą naršyklę.  

![Paveikslėlis1](https://user-images.githubusercontent.com/60034692/194549792-5acf6e90-0a02-468f-b457-f66acb460455.jpg)  
1 pav. Sistemos diegimo diagrama

## Naudotojo sąsajos projektas 
Pradinis (žaidimų) langas:  
![main1](https://user-images.githubusercontent.com/60034692/206909390-288e3924-5267-4cc7-875d-f4ed9b2f554b.png)
![main2](https://user-images.githubusercontent.com/60034692/206909392-7692cdb1-5e6e-413d-afe2-fdc39df132db.png)
![Real1](https://user-images.githubusercontent.com/60034692/206909394-6aaca173-36c0-453d-9696-af936d392864.JPG)
![real2](https://user-images.githubusercontent.com/60034692/206909399-b4ead8cb-d3dc-4d64-a53c-f34908aad9ab.JPG)
![realbig1](https://user-images.githubusercontent.com/60034692/206909424-0c5a3ba9-fb56-4f02-87a8-479f7628add7.JPG)
![realbig2](https://user-images.githubusercontent.com/60034692/206909460-88ba53ed-0302-431b-9c3a-710cc4eb1916.JPG)

Pasirinkto žaidimo langas:  
![gamesmall](https://user-images.githubusercontent.com/60034692/206910041-50dded53-22c3-47c2-85f5-c2dc1b444aec.png)
![gamebig](https://user-images.githubusercontent.com/60034692/206910043-8ec7bb14-d27a-430a-a460-53b85a51e507.png)
![gamesingle](https://user-images.githubusercontent.com/60034692/206910112-4d43e402-50a9-4ba3-a11e-fad2eca43800.JPG)
![gamesingle](https://user-images.githubusercontent.com/60034692/206910050-7c835c64-2b91-41ae-b4fa-e427bb9362b8.JPG)
![gamesmall2](https://user-images.githubusercontent.com/60034692/206910055-5af3703b-a1c0-42d2-8b98-0272f8e52cc8.JPG)

Žaidimo pridėjimas/atnaujinimas:  
![gameaddsmall](https://user-images.githubusercontent.com/60034692/206910511-1db48cbe-8d39-47f2-bc65-46ca44a244c9.png)
![addgame](https://user-images.githubusercontent.com/60034692/206910543-1ec40f6a-75e1-4127-a41b-825c828e881d.png)
![gameaddbig](https://user-images.githubusercontent.com/60034692/206910553-d04eceff-2bd6-4eee-8672-da85427631aa.JPG)
![gameaddsmall1](https://user-images.githubusercontent.com/60034692/206910556-a09dbd6c-fc8b-40c6-a9a4-b359323ad467.JPG)
![gameaddsmall2](https://user-images.githubusercontent.com/60034692/206910559-cc3b262a-44bd-4655-9fc5-a30a0038acef.JPG)

Skelbimo langas su komentarais:  
![advert](https://user-images.githubusercontent.com/60034692/206911347-866f5a7b-bf13-4ead-99d1-b58458ceeeb2.png)
![advertsmall](https://user-images.githubusercontent.com/60034692/206911364-5fda688b-4029-4602-bf2b-3858efe70825.png)
![advertbig](https://user-images.githubusercontent.com/60034692/206911369-acec7ec2-1349-48ef-827f-a602cecd2d9e.JPG)
![advertsmall1](https://user-images.githubusercontent.com/60034692/206911372-bc2296c4-b66a-4e1c-941f-01b9fbbf4417.JPG)
![advertsmall2](https://user-images.githubusercontent.com/60034692/206911378-86b95b48-2e61-45f4-b215-04e057552b31.JPG)

Kitų langų išdėstymas yra panašus (t. y. žaidimų sąrašas pateikiamas panašiai kaip skelbimų sąrašas, pasirinkto žaidimo langas yra panašus į pasirinkto skelbimo langą, skiriasi tik įvesčių/išvesčių tipai)
