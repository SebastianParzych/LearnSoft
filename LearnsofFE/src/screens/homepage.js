import React, {Component} from "react";
import { View, Text, SafeAreaView } from 'react-native'
import Login from './login';


 var user = false;
function hompege_fun() {

    if (user == false){
        return (
               <Login/>
        )
    }else{
        <Homepage/>
    }
}

class Homepage extends Component {
    constructor(username){
        this.username = username.name
        this.id = username.id
    }
    render () {
        <SafeAreaView>
            <Text>
                Congrats you have just landed on homepage!
            </Text>
        </SafeAreaView>
    }

}

export default {
    hompege_fun,
    Homepage
}
