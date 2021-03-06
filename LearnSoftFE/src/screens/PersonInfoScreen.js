import * as React from 'react';
import { Button,TouchableOpacity, View, Text,Image,StyleSheet,Dimensions } from 'react-native';
import { NavigationContainer } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import Logo from './../components/Logo'
import  api from "../api/ApiCaller";

export default  function PersonInfoScreen({ route, navigation }) {

  const  user = route.params.props;
  const host = route.params.host;

  const [Data, SetData] = React.useState({});
  const [ShowInfo, SetInfo] =React.useState(true);
  const [DisplayData, SetDisplay] =React.useState("");
    React.useEffect(() => {
      api.callUserFullInfo({"userid":user.userId})
     .then((response) => response.json())
      .then((responseJson) => {
          console.log("IN FETCH",responseJson)
          if(responseJson.userUnits.length != 0){
            console.log("XD")
           SetDisplay(responseJson.userUnits[0].role+" "+responseJson.userUnits[0].departmentName)
          }
          SetData(responseJson)
      })
      .catch((error) => {
        alert(error);
      }); 
  }, [])




 
  return (
    <View style={{ flex: 1}}>
      <View style={{ flex: 0.9 , justifyContent:'top',  alignItems:'top'}}>
      <Logo header = {user.name+" "+user.surname}/>
      </View>
      <View style={styles.itemImage}>
        <Image source={require('./../../assets/user.png')} style={styles.image}>
        </Image>
      </View>
      <View style = {{flex:2, justifyContent:'top',padding:50,justifyContent:'space-between'}}>
        <View style = {styles.itemUnderImage , {borderWidth:1}}>
          <Text style={styles.text}>
            {DisplayData}
          </Text>
        </View>
         <TouchableOpacity
         style = {styles.itemUnderImage}
          onPress={ () =>{navigation.navigate("Chat", {Data,host})}}>
              <Text style={styles.text}>
            Chat
          </Text>
            </TouchableOpacity>
          <View style={{flex:0.5,padding:10}}>
       
        </View>
      </View>
    </View>
  );
}


const styles = StyleSheet.create({
    itemImage :{

      flex: 1,
      alignItems: 'center',
      justifyContent: 'center',
                  flexGrow: 1,
        flex: 1,
    },
    itemUnderImage :{
      padding:30,
      justifyContent:'center',
       borderWidth:4,
       borderRadius:4
    },
    text : {
    textAlign: 'center', 
    fontSize: 22,
    color : '#ff5c33'
    },
  image: {
    flex: 1,
    resizeMode: 'contain',
    width: 200,
    height: 200
    },
}
)