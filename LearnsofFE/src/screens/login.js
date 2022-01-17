import React, {Component} from "react";
import { Button, TextInput, View, StyleSheet, Dimensions,SafeAreaView} from 'react-native';
import HomePage from './homepage';



var {height,width} = Dimensions.get('window');

class LoginPage extends Component {

    constructor() {
        super();
        this.state = {
            username : "1",
            passowrd : "2"
        }
    }

    onLogin(){
        // Here connect with api and check informations
        var mocked_user = "abc";
        var mocked_password = "123";
        if (this.state.username != mocked_user && this.state.passowrd != mocked_password){
           (password) => this.setState({ password });
           (username) => this.setState({ username });
           return < HomePage/>
        }
        console.log(this.state.username);
        console.log(this.state.password);
    }

    render(){
        return  <SafeAreaView style={{backgroundColor :"red"}}>
            <TextInput 

            value={this.username}
            onChangeText={(username) => this.setState({ username })}
            placeholder={'E-mail'}
            />
            <TextInput 
            value={this.password}
            onChangeText={(password) => this.setState({ password })}
            placeholder={'Password'}
            secureTextEntry={true}
            />
            <Button 
            title={'Login'}
            onPress={this.onLogin.bind(this)}
            />
        </SafeAreaView>
    }
}


export default LoginPage;
