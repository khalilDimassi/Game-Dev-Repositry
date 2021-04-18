<?php

use Symfony\Component\VarDumper\Cloner\Data;

use function GuzzleHttp\Promise\each;

$servername = "localhost";
    $username = "root";
    $password = "";
    $dbName = "players_accounts";

    //Make Connection
    $conn = new mysqli ($servername, $username, $password, $dbName);
    
    //Check Connection if (! Şconn)
    if (!$conn){
        die ("1: Connection Failed". mysqli_connect_error());
    }    

    $name = $_POST["username"];

    $userStatusQuery = " UPDATE users SET online = 0 WHERE username = '" . $name . "';";
    mysqli_query($conn, $userStatusQuery) or die ("2: user status update failed");
    
    $onlineStatusSelectQuery = "SELECT online FROM users WHERE username = '" . $name ."';";
    $onlineStatusSelect = mysqli_query($conn, $usernameCheckQuery) or die("3: online status select failed.");

    
    $onlineStatus = mysqli_fetch_assoc($onlineStatusSelect);
    $online = $onlineStatus["online"];
    
    if ($online == 1) {
        echo "4: status logout update failed";
    }
    elseif ($online == 0) {
        echo "0: status logout success";
    }
    else {
        echo "5: weird stuff happened to online status please check databse";
    }

    // Close connection
    mysqli_close($conn);

?>