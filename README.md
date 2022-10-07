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
4. Matyti skelbimus;  

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

