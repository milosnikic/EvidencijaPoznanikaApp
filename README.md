# EvidencijaPoznanikaApp
Једноставна апликација за потребе предмета Тестирање и квалитет софтвера.
Пре него што се стартује сама апликација потребно је подесити базу. 

Скрипта за креирање схеме базе

> EvidencijaPoznanika.sql

У самој скрипти је потребно изменити две линије, које дефинишу путање складиштења фајлова.

> FILENAME = N'*C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA*\EvidencijaPoznanika.mdf' 

Потребно заменити одговарајућом путањом на вашем рачунару, где је инсталиран SQL Server.

Након тога, потребно је у класи EvidencijaPoznanikaContext линију 42 прилагодити сопственој машини.

> optionsBuilder.UseSqlServer("Server=*DEV-MILOSNI*;Database=EvidencijaPoznanika;Trusted_Connection=True;");

Као и у *appsettings.json* датотеци.

Заменити тако да конекциони стринг одговара вашем рачунару.

Након што је схема базе успешно креирана потребно је попунити тесним подацима. 

Скрипта са подацима за тестирање 

> Podaci.sql

Након тога, потребно је из командне линије ући у фолдер где се налазе сва три пројекта.
> *EvidencijaPoznanikaApp.API*, *EvidencijaPoznanikaApp-SPA* i *EvidencijaPoznanikaTest*

За покретање ВЕБ апликације потребно урадити
============================================
```bash
cd EvidencijaPoznanikaApp-SPA/
npm install #како би се све потребне библиотеке подесиле
ng serve -o
```

За покретање C# апликације потребно је урадити
==============================================
```bash
cd EvidencijaPoznanikaApp.API
dotnet watch run
```

Апликација се отвара у претраживачу на адреси локалног рачунара са портом 4200
------------------------------------------------------------------------------
