import React, {Component} from "react";
import { Alert, Button, TextInput, View, StyleSheet } from 'react-native';


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
        }
        console.log(this.state.username);
        console.log(this.state.password);
    }
    
    render(){
        return  <View >
            <TextInput
            value={this.username}
            onChangeText={(username) => this.setState({ username })}
            placeholder={'E-mail'}
            //style={styles.input}
            />
            <TextInput
            value={this.password}
            onChangeText={(password) => this.setState({ password })}
            placeholder={'Password'}
            secureTextEntry={true}
            //style={styles.input}
            />
            
            <Button
            title={'Login'}
            //style={styles.input}
            onPress={this.onLogin.bind(this)}
            />
        </View>
    }
}

export default LoginPage;