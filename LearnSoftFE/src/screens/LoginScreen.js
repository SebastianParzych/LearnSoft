import React, {Component} from "react";
import { Button,
    TextInput,
    View,
    StyleSheet,
    Dimensions,
    SafeAreaView,
    Image,
    TouchableHighlightBase} from 'react-native';
    
import  api from "../api/ApiCaller";
import styles from "../Styles"
import ActionButton from "./../components/ActionButton"



class LoginPage extends Component {

    constructor(props) {
        super();

        this.state = {
            username : "",
            password : ""
        }
    }

    onLogin(){
        // Here connect with api and check informations
        if (this.state.username =="" && this.state.password==""){
            return
        }
        var api_resp = api.callLogin({"login": this.state.username , 
                            "password": this.state.password})
        api_resp.then((userData)=>{
            if( userData.status != 404){
                    this.props.navigation.navigate('Menu',{userData})
            }
        setTimeout (()=>{
        }, 2000)
        })
    }   

    render(){
        return <View style={styles.containerTop} >
        <View style={styles.containerTop}>
            <Image 
                source={require('./../../assets/logo.png')} 
                style={styles.centralImage}/>
        </View>  
        <View style={styles.container}  >
            
            <TextInput 
                style = {styles.input}
                value={this.username}
                onChangeText={(username) => this.setState({ username })}
                placeholder={'E-mail'}
            />
            <TextInput 
                style = {styles.input}
                value={this.password}
                onChangeText={(password) => this.setState({ password })}
                placeholder={'Password'}
                secureTextEntry={true}
            />
            <ActionButton
                text = 'Zaloguj się'
                onPress={this.onLogin.bind(this)}
            />
        </View>
    </View>  
    }
}


export default LoginPage;

