import React, {Component} from "react";
import { View, Text } from "react-native";
import { registerRootComponent } from 'expo';
import  Log_Page from './pages/login'



class App extends Component {

  constructor () {
      super();
      this.login_status = this.check_login_status();

  }

  check_login_status(){
      this.state = {
        username : '',
        password : '',
      };
      return false;
  }


  render() {
    return <View>
               <Log_Page />
          </View>
  }
}

export default App;
registerRootComponent(App);