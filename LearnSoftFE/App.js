

import React, { useState } from 'react';
import { StyleSheet, Text, View , Button,Dimensions, Image, TouchableHighlight} from 'react-native';
import LoginPage from './src/screens/LoginPage';


var {height,width} = Dimensions.get('window');





export default function App() {

  const [current, setCurrent] = useState('Home');
  const HomeScreen = (
        <View style={styles.container} >
          <TouchableHighlight   onPress={()=>setCurrent(DashboardScreen)}>
          <Image source={require('./assets/logo.png')} style={styles.image} />
        </TouchableHighlight>
        <Text> Home Screen</Text>
        <Button
        title = "Login"
        onPress={()=>setCurrent(DashboardScreen)}
        ></Button>
      </View>
    );
  const LoginPageScreen  = (
      <LoginPage/>
  )
  const DashboardScreen =(
    <View style={styles.container} >
      <Text>Your Menu</Text>
      <Button
      title = "Back"
      onPress = {()=>setCurrent(HomeScreen)}
      ></Button>
    </View>

    );
    return current == "Home" ? HomeScreen : LoginPageScreen;
  
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
  image: {
    flex: 1,
  resizeMode: 'contain',
  width: 300,
  height: 300
}
});
