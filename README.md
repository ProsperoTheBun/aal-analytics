#  Analytics Dashboard
### Author: Marcus Cunningham

Based on specification: [CodingChallenge.docx](/CodingChallenge.docx)

## Installation and running
1. Clone the repo to your local machine.
2. Restore the database from the AA.CommoditiesDashboard.bak file to your local SQL Server instance. \
In my case, in SSMS, I ran the following ...

```sql
RESTORE DATABASE [AA.CommoditiesDashboard] FROM DISK='%USERPROFILE%\source\repos\AAL\aal-analytics\AA.CommoditiesDashboard.bak'
WITH 
MOVE 'AA.CommoditiesDashboard' TO '%LOCALAPPDATA%\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\AA.CommoditiesDashboard.mdf',
MOVE 'AA.CommoditiesDashboard_log' TO '%LOCALAPPDATA%\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\AA.CommoditiesDashboard_log.ldf'
```
(Change the DISK path to wherever the file is locally. You'll also need to replace the placeholders `'%USERPROFILE%` and `%LOCALAPPDATA%`.)

If, for any reason, your database connection string needs to be changed from `Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AA.CommoditiesDashboard;Integrated Security=True;`, you can edit the value in `appsetttings.Development.json`.

```json
{
  "ConnectionStrings": {
    "AA.CommoditiesDashboard": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AA.CommoditiesDashboard;Integrated Security=True;"
  }
}
```

3. Start the API from VS as normal (defaults to http://localhost:5000)
4. Build the UI with `npm install`
5. Start the UI with `ng serve` (defaults to http://localhost:4200)

## Notes
* _I changed the test runner on Angular to Jest because (I think) I was having clashes between my global version of Angular (v13) and the boiler-plate project version (v12) which were taking too long to resolve. Use `npm run test` to run the unit tests._



