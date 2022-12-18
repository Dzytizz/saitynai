## Sprendžiamo uždavinio aprašymas

### Sistemos paskirtis

Kuriama sistema leis palengvinti turimų stalo žaidimų pardavimą su kitais stalo žaidimų mėgėjais. 
Sistema leidžia administratoriui pridėti stalo žaidimus prie sistemos. Esamiems žaidimams sistemoje prisijungę naudotojai gali patalpinti skelbimus, kuriuose aprašomas parduodamas stalo žaidimas (pateikiamas turimo žaidimo būklės įvertinimas, nuotraukos). Kiti prisiregistravę sistemos naudotojai gali palikti komentarus apie skelbimą. Sistemos naudotojai administratoriui gali pateikti užklausas pridėti daugiau stalo žaidimų prie sistemos jei siekiama kurti skelbimą žaidimui kurio nėra sistemoje.  
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

Administratorius gali:  
1. Peržiūrėti žaidimus;  
2. Peržiūrėti skelbimus;  
3. Šalinti paskyras iš sistemos;  
4. Šalinti skelbimus iš sistemos;  
5. Redaguoti skelbimus;  
6. Pridėti žaidimus prie sistemos;  
7. Šalinti žaidimus iš sistemos;  
8. Redaguoti žaidimų informaciją.  

## Pasirinktų technologijų aprašymas

- Kliento dalies kodas (angl. front-end) kuriamas naudojantis „React“
- Serverio dalies kodas (angl. back-end) kuriamas naudojant „.NET Core 6.0“.
- Duomenų bazė – „MySQL“.  

„React“ - nemokama atvirojo kodo „JavaScript“ biblioteka, skirta kurti vartotojo sąsajas, pagrįstas UI komponentais.  
„.NET Core“ – yra nemokama ir atviro kodo valdoma kompiuterinės programinės įrangos sistema, skirta „Windows“, „Linux“ ir „macOS“ operacinėms sistemoms. Leidžia kurti serverio pusės kodą naudojant C# programavimo kalbą.  
MySQL – viena iš reliacinių duomenų bazių valdymo sistemų, palaikanti daugelį naudotojų, dirbanti SQL kalbos pagrindu.

## Sistemos architektūra

Sistemos architektūrai aiškinti pateikiama UML diegimo diagrama (žr. 1 pav.). Serveris (šiuo atveju kompiuteryje sukurtas serveris) komunikuoja su kitais kompiuteriais naudojant HTTPS protokolą. Sistema galima naudotis ją atidarius per pasirinktą naršyklę.  

![Paveikslėlis1](https://user-images.githubusercontent.com/60034692/194549792-5acf6e90-0a02-468f-b457-f66acb460455.jpg)  
1 pav. Sistemos diegimo diagrama

## Naudotojo sąsajos projektas (wireframe'ai ir realizacija mažame (telefono) ir dideliame ekrane)
Pradinis (žaidimų) langas:  
![1](https://user-images.githubusercontent.com/60034692/208305018-57538dea-1543-4f66-b4b0-d3a78a786da4.JPG)
![2](https://user-images.githubusercontent.com/60034692/208305030-e5b90952-93e7-40af-8abf-6a562e62bfec.JPG)
![Real1](https://user-images.githubusercontent.com/60034692/206909394-6aaca173-36c0-453d-9696-af936d392864.JPG)
![real2](https://user-images.githubusercontent.com/60034692/206909399-b4ead8cb-d3dc-4d64-a53c-f34908aad9ab.JPG)
![realbig1](https://user-images.githubusercontent.com/60034692/206909424-0c5a3ba9-fb56-4f02-87a8-479f7628add7.JPG)
![realbig2](https://user-images.githubusercontent.com/60034692/206909460-88ba53ed-0302-431b-9c3a-710cc4eb1916.JPG)

Pasirinkto žaidimo langas:  
![3](https://user-images.githubusercontent.com/60034692/208305072-45f19ba6-4ad1-4e80-9fff-db353ac75d18.JPG)
![10](https://user-images.githubusercontent.com/60034692/208305085-316cc33b-76e8-443d-b5a6-fe6a26cd20ec.JPG)
![gamesingle](https://user-images.githubusercontent.com/60034692/206910112-4d43e402-50a9-4ba3-a11e-fad2eca43800.JPG)
![gamesingle](https://user-images.githubusercontent.com/60034692/206910050-7c835c64-2b91-41ae-b4fa-e427bb9362b8.JPG)
![gamesmall2](https://user-images.githubusercontent.com/60034692/206910055-5af3703b-a1c0-42d2-8b98-0272f8e52cc8.JPG)

Žaidimo pridėjimas/atnaujinimas:  
![4](https://user-images.githubusercontent.com/60034692/208305100-dd9db540-fa05-465d-a382-3d1482eab0a8.JPG)
![141](https://user-images.githubusercontent.com/60034692/208305106-698efbff-8bab-448f-9d4d-aebfce3968a5.JPG)
![gameaddbig](https://user-images.githubusercontent.com/60034692/206910553-d04eceff-2bd6-4eee-8672-da85427631aa.JPG)
![gameaddsmall1](https://user-images.githubusercontent.com/60034692/206910556-a09dbd6c-fc8b-40c6-a9a4-b359323ad467.JPG)
![gameaddsmall2](https://user-images.githubusercontent.com/60034692/206910559-cc3b262a-44bd-4655-9fc5-a30a0038acef.JPG)

Skelbimo langas su komentarais:  
![5](https://user-images.githubusercontent.com/60034692/208305116-b4cc4f96-6438-47c5-b47d-5b1c38f75b68.JPG)
![15](https://user-images.githubusercontent.com/60034692/208305128-2daddef9-f102-4a6a-9742-769f2d5ac671.JPG)
![advertbig](https://user-images.githubusercontent.com/60034692/206911369-acec7ec2-1349-48ef-827f-a602cecd2d9e.JPG)
![advertsmall1](https://user-images.githubusercontent.com/60034692/206911372-bc2296c4-b66a-4e1c-941f-01b9fbbf4417.JPG)
![advertsmall2](https://user-images.githubusercontent.com/60034692/206911378-86b95b48-2e61-45f4-b215-04e057552b31.JPG)

Prisijungimas ir registracija:
![login](https://user-images.githubusercontent.com/60034692/208305158-aa9766cc-7e7b-4a5b-ba5e-6a0d26212023.JPG)
![register](https://user-images.githubusercontent.com/60034692/208305160-5d3da969-42e4-4b96-9622-1265ee3424ea.JPG)
![dasdasd](https://user-images.githubusercontent.com/60034692/208305164-e0d0bf59-b0d1-457a-8174-651fb661affe.JPG)
![adsads](https://user-images.githubusercontent.com/60034692/208305166-00c3077b-28ce-4807-9611-fb02c53f1507.JPG)


Kitų langų išdėstymas yra panašus (t. y. žaidimų sąrašas pateikiamas panašiai kaip skelbimų sąrašas, pasirinkto žaidimo langas yra panašus į pasirinkto skelbimo langą, skiriasi tik įvesčių/išvesčių tipai)

## API specifikacija

Iš viso sukurti 19 API endpoint'ų. Pagal Twitter specifikaciją aprašomi 17 iš jų (likę 2 yra pagalbiniai, failų įkėlimui ir šalinimui iš serverio).
| Metodas | Endpoint URL | Autentifikavimas | Užklausos parametrai | Atsako kodai | Pavyzdys |
| --- | --- | --- | --- | --- | --- |
| GET | https://saitynai-server.azurewebsites.net/api/v1/games | Nėra | Nėra | 200 | Užklausa: https://saitynai-server.azurewebsites.net/api/v1/games |

Atsakas:  
```yaml
[
    {
        "id": 1,
        "title": "Sagrada",
        "description": "Šiame žaidime tapsite vitražų meistrais ir varžysitės dėl didžiausio šedevro kūrėjo titulo.",
        "minPlayers": 2,
        "maxPlayers": 4,
        "rules": "Žaidimo eigoje  rinksite kauliukus ir iš jų dėliosite savo vitražą. Ne visi kauliukai dera tarpusavyje: panašių atspalvių kauliukai negali būti greta vienas kito, turimos žaidimo lentelės taip pat įveda papildomų apribojimų, kuriuos galite apeiti panaudodami specialius įrankius.",
        "difficulty": 3,
        "photos": "jfhua0ct.jpg;"
    },
    {
        "id": 2,
        "title": "Uno",
        "description": "Vienas populiariausių kortų žaidimų",
        "minPlayers": 2,
        "maxPlayers": 10,
        "rules": "Paeiliui, žaidėjai bando padėti kortą sutampančią pagal skaičių arba spalvą su korta ant stalo viduryje esančios kortų krūvos viršaus. Jeigu jie negali kortos dėti, jie turi traukti naują kortą, ir jeigu vis dar negali, turi praleisti ėjimą.",
        "difficulty": 2,
        "photos": "jhaop1yh.jpg;"
    }
]
```
| Metodas | Endpoint URL | Autentifikavimas | Užklausos parametrai | Atsako kodai | Pavyzdys |
| --- | --- | --- | --- | --- | --- |
| GET | https://saitynai-server.azurewebsites.net/api/v1/games/:id | Nėra | id - žaidimo identifikatorius | 200 | Užklausa: https://saitynai-server.azurewebsites.net/api/v1/games/1 |

Atsakas:  
```yaml
{
    "id": 1,
    "title": "Sagrada",
    "description": "Šiame žaidime tapsite vitražų meistrais ir varžysitės dėl didžiausio šedevro kūrėjo titulo.",
    "minPlayers": 2,
    "maxPlayers": 4,
    "rules": "Žaidimo eigoje  rinksite kauliukus ir iš jų dėliosite savo vitražą. Ne visi kauliukai dera tarpusavyje: panašių atspalvių kauliukai negali būti greta vienas kito, turimos žaidimo lentelės taip pat įveda papildomų apribojimų, kuriuos galite apeiti panaudodami specialius įrankius.",
    "difficulty": 3,
    "photos": "jfhua0ct.jpg;"
}
```
| Metodas | Endpoint URL | Autentifikavimas | Užklausos parametrai | Atsako kodai | Pavyzdys |
| --- | --- | --- | --- | --- | --- |
| POST | https://saitynai-server.azurewebsites.net/api/v1/games | JWT Token: reikalinga Admin rolė | Žaidimo objektas | 201, 400, 401, 403, 404 | Užklausa: https://saitynai-server.azurewebsites.net/api/v1/games |

Atsakas:  
```yaml
{
    "id": 4,
    "title": "Naujas žaidimas",
    "description": "Naujo žaidimo aprašymas.",
    "minPlayers": 2,
    "maxPlayers": 4,
    "rules": "ŽŽaidi ir laimi.",
    "difficulty": 1,
    "photos": "efhha0ct.jpg;"
}
```
| Metodas | Endpoint URL | Autentifikavimas | Užklausos parametrai | Atsako kodai | Pavyzdys |
| --- | --- | --- | --- | --- | --- |
| PUT | https://saitynai-server.azurewebsites.net/api/v1/games/:id | JWT Token: reikalinga Admin rolė | id - žaidimo identifikatorius, Žaidimo objektas | 200, 400, 401, 403, 404 | Užklausa: https://saitynai-server.azurewebsites.net/api/v1/games/1 |

Atsakas:  
```yaml
{
    "id": 1,
    "title": "Pakeistas žaidimas",
    "description": "Pakeistas aprašymas.",
    "minPlayers": 2,
    "maxPlayers": 4,
    "rules": "Pakeistos taisyklės",
    "difficulty": 1,
    "photos": "xjkha0ci.jpg;"
}
```
| Metodas | Endpoint URL | Autentifikavimas | Užklausos parametrai | Atsako kodai | Pavyzdys |
| --- | --- | --- | --- | --- | --- |
| DELETE | https://saitynai-server.azurewebsites.net/api/v1/games/:id | JWT Token: reikalinga Admin rolė | id - žaidimo identifikatorius | 204, 401, 403, 400 | Užklausa: https://saitynai-server.azurewebsites.net/api/v1/games/1 |
Atsakas:  
```yaml

```
| Metodas | Endpoint URL | Autentifikavimas | Užklausos parametrai | Atsako kodai | Pavyzdys |
| --- | --- | --- | --- | --- | --- |
| GET | https://saitynai-server.azurewebsites.net/api/v1/games/:gameId/advertisements | Nėra | gameId - žaidimo identifikatorius | 200, 400 | Užklausa: https://saitynai-server.azurewebsites.net/api/v1/games/1/advertisements |

Atsakas:  
```yaml
[
    {
        "id": 15,
        "title": "Parduodu Sagrada",
        "editDate": "2022-12-10T21:24:32.3371307",
        "description": "Parduodu labai geros būklės Sagrada žaidimą. Tel. nr: 86**********.",
        "condition": 10,
        "price": 25.55,
        "photos": "vl2cvpyv.jpg;",
        "exchangeToGame": null,
        "fkGame": {
            "id": 1,
            "title": "Sagrada",
            "description": "Šiame žaidime tapsite vitražų meistrais ir varžysitės dėl didžiausio šedevro kūrėjo titulo.",
            "minPlayers": 2,
            "maxPlayers": 4,
            "rules": "Žaidimo eigoje  rinksite kauliukus ir iš jų dėliosite savo vitražą. Ne visi kauliukai dera tarpusavyje: panašių atspalvių kauliukai negali būti greta vienas kito, turimos žaidimo lentelės taip pat įveda papildomų apribojimų, kuriuos galite apeiti panaudodami specialius įrankius.",
            "difficulty": 3,
            "photos": "jfhua0ct.jpg;"
        }
    },
    {
        "id": 16,
        "title": "Parduodu Sagrada žaidimą",
        "editDate": "2022-12-10T21:26:20.3336167",
        "description": "Parduodamas naudotas Sagrada žaidimas. Kontaktinis el. paštas: email@email.com",
        "condition": 8,
        "price": 20.00,
        "photos": "d4otqbpp.jpg;",
        "exchangeToGame": null,
        "fkGame": {
            "id": 1,
            "title": "Sagrada",
            "description": "Šiame žaidime tapsite vitražų meistrais ir varžysitės dėl didžiausio šedevro kūrėjo titulo.",
            "minPlayers": 2,
            "maxPlayers": 4,
            "rules": "Žaidimo eigoje  rinksite kauliukus ir iš jų dėliosite savo vitražą. Ne visi kauliukai dera tarpusavyje: panašių atspalvių kauliukai negali būti greta vienas kito, turimos žaidimo lentelės taip pat įveda papildomų apribojimų, kuriuos galite apeiti panaudodami specialius įrankius.",
            "difficulty": 3,
            "photos": "jfhua0ct.jpg;"
        }
    }
]
```
| Metodas | Endpoint URL | Autentifikavimas | Užklausos parametrai | Atsako kodai | Pavyzdys |
| --- | --- | --- | --- | --- | --- |
| GET | https://saitynai-server.azurewebsites.net/api/v1/games/:gameId/advertisements/:id | Nėra | gameId - žaidimo identifikatorius, id - skelbimo identifikatorius | 200, 400 | Užklausa: https://saitynai-server.azurewebsites.net/api/v1/games/1/advertisements/15 |

Atsakas:  
```yaml
{
    "id": 15,
    "title": "Parduodu Sagrada",
    "editDate": "2022-12-10T21:24:32.3371307",
    "description": "Parduodu labai geros būklės Sagrada žaidimą. Tel. nr: 86**********.",
    "condition": 10,
    "price": 25.55,
    "photos": "vl2cvpyv.jpg;",
    "exchangeToGame": null,
    "fkGame": {
        "id": 1,
        "title": "Sagrada",
        "description": "Šiame žaidime tapsite vitražų meistrais ir varžysitės dėl didžiausio šedevro kūrėjo titulo.",
        "minPlayers": 2,
        "maxPlayers": 4,
        "rules": "Žaidimo eigoje  rinksite kauliukus ir iš jų dėliosite savo vitražą. Ne visi kauliukai dera tarpusavyje: panašių atspalvių kauliukai negali būti greta vienas kito, turimos žaidimo lentelės taip pat įveda papildomų apribojimų, kuriuos galite apeiti panaudodami specialius įrankius.",
        "difficulty": 3,
        "photos": "jfhua0ct.jpg;"
    }
}
```
| Metodas | Endpoint URL | Autentifikavimas | Užklausos parametrai | Atsako kodai | Pavyzdys |
| --- | --- | --- | --- | --- | --- |
| POST | https://saitynai-server.azurewebsites.net/api/v1/games/:gameId/advertisements | JWT Token: reikalinga User rolė | gameId - žaidimo identifikatorius, Skelbimo objektas | 201, 400, 401, 403, 404 | Užklausa: https://saitynai-server.azurewebsites.net/api/v1/games/1/advertisements |

Atsakas:  
```yaml
{
    "id": 19,
    "title": "Naujas skelbimas",
    "editDate": "2022-13-10T21:24:32.3371307",
    "description": "Parduodu labai geros būklės naują žaidimą. Tel. nr: 86**********.",
    "condition": 10,
    "price": 25.55,
    "photos": "z79cvpyv.jpg;",
    "exchangeToGame": null,
    "fkGame": {
        "id": 1,
        "title": "Sagrada",
        "description": "Šiame žaidime tapsite vitražų meistrais ir varžysitės dėl didžiausio šedevro kūrėjo titulo.",
        "minPlayers": 2,
        "maxPlayers": 4,
        "rules": "Žaidimo eigoje  rinksite kauliukus ir iš jų dėliosite savo vitražą. Ne visi kauliukai dera tarpusavyje: panašių atspalvių kauliukai negali būti greta vienas kito, turimos žaidimo lentelės taip pat įveda papildomų apribojimų, kuriuos galite apeiti panaudodami specialius įrankius.",
        "difficulty": 3,
        "photos": "jfhua0ct.jpg;"
    }
}
```
| Metodas | Endpoint URL | Autentifikavimas | Užklausos parametrai | Atsako kodai | Pavyzdys |
| --- | --- | --- | --- | --- | --- |
| PUT | https://saitynai-server.azurewebsites.net/api/v1/games/:gameId/advertisements/:id | JWT Token: reikalinga User/Admin rolė, resuras priklauso User | gameId - žaidimo identifikatorius, id - skelbimo identifikatorius, Skelbimo objektas | 200, 400, 401, 403, 404 | Užklausa: https://saitynai-server.azurewebsites.net/api/v1/games/1/advertisements/15 |

Atsakas:  
```yaml
{
    "id": 15,
    "title": "Pakeistas skelbimas",
    "editDate": "2022-14-10T21:24:32.3371307",
    "description": "Pakeista skelbimo informacija",
    "condition": 10,
    "price": 25.55,
    "photos": "465cvpyv.jpg;",
    "exchangeToGame": null,
    "fkGame": {
        "id": 1,
        "title": "Sagrada",
        "description": "Šiame žaidime tapsite vitražų meistrais ir varžysitės dėl didžiausio šedevro kūrėjo titulo.",
        "minPlayers": 2,
        "maxPlayers": 4,
        "rules": "Žaidimo eigoje  rinksite kauliukus ir iš jų dėliosite savo vitražą. Ne visi kauliukai dera tarpusavyje: panašių atspalvių kauliukai negali būti greta vienas kito, turimos žaidimo lentelės taip pat įveda papildomų apribojimų, kuriuos galite apeiti panaudodami specialius įrankius.",
        "difficulty": 3,
        "photos": "jfhua0ct.jpg;"
    }
}
```
| Metodas | Endpoint URL | Autentifikavimas | Užklausos parametrai | Atsako kodai | Pavyzdys |
| --- | --- | --- | --- | --- | --- |
| DELETE | https://saitynai-server.azurewebsites.net/api/v1/games/:gameId/advertisements/:id | JWT Token: reikalinga User/Admin rolė, resuras priklauso User | gameId - žaidimo identifikatorius, id - skelbimo identifikatorius | 204, 400, 401, 403 | Užklausa: https://saitynai-server.azurewebsites.net/api/v1/games/1/advertisements/15 |
Atsakas:  
```yaml

```
| Metodas | Endpoint URL | Autentifikavimas | Užklausos parametrai | Atsako kodai | Pavyzdys |
| --- | --- | --- | --- | --- | --- |
| GET | https://saitynai-server.azurewebsites.net/api/v1/games/:gameId/advertisemets/:addId/comments | Nėra | gameId - žaidimo identifikatorius, addId - skelbimo identifikatorius | 200, 400 | Užklausa: https://saitynai-server.azurewebsites.net/api/v1/games/1/advertisements/15/comments |

Atsakas:  
```yaml
[
    {
        "id": 13,
        "editDate": "2022-12-10T21:26:38.2885632",
        "description": "Labai geros būklės",
        "fkAdvertisementId": 15
    },
    {
        "id": 14,
        "editDate": "2022-12-10T21:26:54.5863432",
        "description": "Ar derinate kainą?",
        "fkAdvertisementId": 15
    }
]
```
| Metodas | Endpoint URL | Autentifikavimas | Užklausos parametrai | Atsako kodai | Pavyzdys |
| --- | --- | --- | --- | --- | --- |
| GET | https://saitynai-server.azurewebsites.net/api/v1/games/:gameId/advertisements/:addId/comments/:id | Nėra  | gameId - žaidimo identifikatorius, addId - skelbimo identifikatorius, id - komentaro identifikatorius | 200, 400 | Užklausa: https://saitynai-server.azurewebsites.net/api/v1/games/1/advertisements/15/comments/13 |

Atsakas:  
```yaml
{
    "id": 13,
    "editDate": "2022-12-10T21:26:38.2885632",
    "description": "Labai geros būklės",
    "fkAdvertisementId": 15
}
```
| Metodas | Endpoint URL | Autentifikavimas | Užklausos parametrai | Atsako kodai | Pavyzdys |
| --- | --- | --- | --- | --- | --- |
| POST | https://saitynai-server.azurewebsites.net/api/v1/games/:gameId/advertisements/:addId/comments | JWT Token: reikalinga User/Admin rolė | gameId - žaidimo identifikatorius, addId - skelbimo identifikatorius, Komentaro objektas | 201, 400, 401, 403, 404 | Užklausa: https://saitynai-server.azurewebsites.net/api/v1/games/1/advertisements/15/comments |

Atsakas:  
```yaml
{
    "id": 15,
    "editDate": "2022-13-10T21:26:54.5863432",
    "description": "Naujas komentaras",
    "fkAdvertisementId": 15
}
```
| Metodas | Endpoint URL | Autentifikavimas | Užklausos parametrai | Atsako kodai | Pavyzdys |
| --- | --- | --- | --- | --- | --- |
| PUT | https://saitynai-server.azurewebsites.net/api/v1/games/:gameId/advertisements/:addId/comments/:id | JWT Token: reikalinga User/Admin rolė, resuras priklauso User | gameId - žaidimo identifikatorius, addId - skelbimo identifikatorius, id - komentaro identifikatorius, Komentaro objektas | 200, 400, 401, 403, 404 | Užklausa: https://saitynai-server.azurewebsites.net/api/v1/games/1/advertisements/15/comments/15 |

Atsakas:  
```yaml
{
    "id": 15,
    "editDate": "2022-14-10T21:26:54.5863432",
    "description": "Redaguotas komentaras",
    "fkAdvertisementId": 15
}
```
| Metodas | Endpoint URL | Autentifikavimas | Užklausos parametrai | Atsako kodai | Pavyzdys |
| --- | --- | --- | --- | --- | --- |
| DELETE | https://saitynai-server.azurewebsites.net/api/v1/games/:gameId/advertisements/:addId/comments/:id | JWT Token: reikalinga User/Admin rolė, resuras priklauso User | gameId - žaidimo identifikatorius, addId - skelbimo identifikatorius, id - komentaro identifikatorius | 204, 400, 401, 403 | Užklausa: https://saitynai-server.azurewebsites.net/api/v1/games/1/advertisements/15/comments/15 |
Atsakas:  
```yaml

```
| Metodas | Endpoint URL | Autentifikavimas | Užklausos parametrai | Atsako kodai | Pavyzdys |
| --- | --- | --- | --- | --- | --- |
| POST | https://saitynai-server.azurewebsites.net/api/v1/login | Nėra | Naudotojo prisijungimo objektas | 200, 404 | Užklausa: https://saitynai-server.azurewebsites.net/api/v1/login |

Atsakas:  
```yaml
{
    "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidXNlcjEiLCJqdGkiOiI4MzBkOWQwMC05MDNkLTQyYzUtYjExNC04YzE0MDRjMWI0MWUiLCJzdWIiOiI5MmY0NDdiOC0wOWRiLTRlMjQtOGFhZi00MGRlZjhlMDNlYjEiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc2VyIiwiZXhwIjoxNjcwNzc0NjIzLCJpc3MiOiJWYWxpZElzc3VlciIsImF1ZCI6IlRydXN0ZWRDbGllbnQifQ.0VjYdIQ8ewIJriMjj2dGhpieAi45R441p6-uEIbNgwM",
    "roles": [
        "User"
    ]
}
```
| Metodas | Endpoint URL | Autentifikavimas | Užklausos parametrai | Atsako kodai | Pavyzdys |
| --- | --- | --- | --- | --- | --- |
| POST | https://saitynai-server.azurewebsites.net/api/v1/register | Nėra | Naudotojo registracijos objektas | 200, 404 | Užklausa: https://saitynai-server.azurewebsites.net/api/v1/register |

Atsakas:  
```yaml
{
    "id": "34d01c79-eb50-4db9-a360-a0354fabf947",
    "userName": "user4",
    "email": "email@gmail.com"
}
```

## Išvados
Projekto kūrimo metu pagilintos žinios kuriant serverio pusės kodą (angl. backend) naudojant ".NET Core 6" karkasą ir kliento pusės kodą (angl. frontend) naudojant "React" su "Material UI" paketu. Sėkmingai sukurti 19 API endpoint'ų, kurie leidžia sistemai veikti. Atliktas serverio pusės diegimas debesyje naudojant "Azure" paslaugas. Įgyvendinta sistema, leidžianti naudotojams parduoti turimus stalo žaidimus.
