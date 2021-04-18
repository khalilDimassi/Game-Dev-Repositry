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
   $password = $_POST["password"];

   //check if username exists and pull out the password for auth
    $usernameCheckQuery = "SELECT username, id, password, online FROM users WHERE username = '" . $name ."';";
    $usernameCheck = mysqli_query($conn, $usernameCheckQuery) or die("2: username check failed.");

    if (mysqli_num_rows($usernameCheck) != 1) {
        echo "3: either no user with such username OR more than one registered with this username.";
        exit();
    }

    $userLoginData = mysqli_fetch_assoc($usernameCheck);
    $hash = $userLoginData["password"];
    $userID = $userLoginData["id"];
    $userStatus = $userLoginData["online"];
    $name = $userLoginData["username"];
    
    if (!password_verify($password, $hash)) {
        echo "4: incorrect password";
        exit();
    }
    elseif ($userStatus == 1) {
        echo "5: user online on another device";
        exit();
    }
    else {
        $userStatusQuery = " UPDATE users SET online = 1 WHERE username = '" . $name . "';";
        mysqli_query($conn, $userStatusQuery) or die ("7: user status update failed");
    }

    $PdataFetchQuery = "SELECT * FROM profiles WHERE user_id = '" . $userID . "';";
    $PdataFetch = mysqli_query($conn, $PdataFetchQuery) or die("6: User data pull from profile failed");
    $Pdata = mysqli_fetch_assoc($PdataFetch);

    function formulate($array, $name){
        $formulated_data = "0";
        foreach ($array as $info) {
            $formulated_data .= "\t" . $info;
        }
        return ($formulated_data. "\t" . $name);
    }

    echo (formulate($Pdata, $name) ) ;

    
    // Close connection
    mysqli_close($conn);

?>