<?php   

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

   $username = $_POST["username"];
   $password = $_POST["password"];

   //check if name exists
    $usernameCheckQuery = "SELECT username, id, password FROM users WHERE username = '" . $username ."';";
    $usernameCheck = mysqli_query($conn, $usernameCheckQuery) or die("2: username check failed.");

    if (mysqli_num_rows($usernameCheck) != 1) {
        echo "3: either no user with such username OR more than one registered with this username.";
        exit();
    }

    $userLoginData = mysqli_fetch_assoc($usernameCheck);
    $hash = $userLoginData["password"];
    $userID = $userLoginData["id"];
    
    if (!password_verify($password, $hash)) {
        echo '4: incorrect password';
        exit();
    }

    $dataFetchQuery = "SELECT * FROM profiles WHERE user_id = '" . $userID . "';";
    $dataFetch = mysqli_query($conn, $dataFetchQuery) or die("5: User data pull from profile failed");
    $data = mysqli_fetch_assoc($dataFetch);

    echo "0\t" . $data;

    
    // Close connection
    mysqli_close($conn);

?>