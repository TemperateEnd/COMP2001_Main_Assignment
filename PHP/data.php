<!DOCTYPE html>
<html>
    <head>
        <title> RTarrant COMP2001 Site - Data </title>
        <style>
            table {
                margin: 0 auto;
                font-size: large;
                border: 1px solid black;
            }

            h1 {
                text-align: center;
                color: #006600;
                font-size: xx-large;
                font-family: 'Gill Sans',
                'Gill Sans MT', ' Calibri',
                'Trebuchet MS', 'sans-serif';
            }

            h2 {
                text-align: center;
                color: #000600;
                font-size: x-large;
                font-family: 'Gill Sans',
                'Gill Sans MT', ' Calibri',
                'Trebuchet MS', 'sans-serif';
            }

            td {
                background-color: #E4F5D4;
                border: 1px solid black;
            }

            th,
            td {
                font-weight: bold;
                border: 1px solid black;
                padding: 10px;
                text-align: center;
            }

            td {
                font-weight: lighter;
            }
        </style>
    </head>
<body>
    <h1> RTarrant COMP2001 Site </h1>
    <h2> Data Table </h2>

    <?php
        echo "<body><table>\n\n";
        $f = fopen("dataset.csv", "r");
        while (($line = fgetcsv($f)) !== false) {
            foreach ($line as $cell) {
                echo "<tr><td>" . htmlspecialchars($cell) . "</td>";
            }
            echo "</tr>";
        }
        fclose($f);
        echo "\n</table></body>";
    ?>

</body>
</html>
