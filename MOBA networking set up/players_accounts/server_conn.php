<?php   

    $servername = "localhost";
    $username = "root";
    $password = "";
    $dbName = "players_accounts";

    //Make Connection
    $conn = new mysqli ($servername, $username, $password, $dbName);
    
    //Check Connection if (! Şconn)
    if (!$conn){
        die ("Connection Failed". mysqli_connect_error ());
    }    

    $sql = "SELECT id, name, username, email, password FROM users";
    $res = mysqli_query($conn, $sql);

    if (mysqli_num_rows($res) > 0) {
        while ($row = mysqli_fetch_assoc($res)) {
            echo "id: ".$row["id"] . " || name: ".$row["name"] . " || username: ".$row["username"] . 
                  " || email: ".$row["email"] . " || password: ".$row["password"] . "<br>";
        }
    }

?>