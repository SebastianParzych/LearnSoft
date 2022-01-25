import React, {Component} from "react";
import { Button,
    TextInput,
    View,
    StyleSheet,
    Dimensions,
    SafeAreaView,
    Image,
    TouchableHighlightBase} from 'react-native';
    
import  callLogin from "../api/ApiCaller";
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
        var api_resp = callLogin({"login": this.state.username , 
                            "password": this.state.password})

        console.log(this.state);      
        console.log("API RESPONSE",api_resp); 
        api_resp.then((responseJson)=>{
            console.log('getting data from fetch',responseJson)
            if( responseJson.status != 404){
                    this.props.navigation.navigate('Menu')
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

