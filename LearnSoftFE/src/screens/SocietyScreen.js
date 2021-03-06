import * as React from 'react';
import { TouchableOpacity ,FlatList,SafeAreaView, Button, View,TextInput, Text, StyleSheet ,Dimensions} from 'react-native';
import { NavigationContainer, } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import  api from "../api/ApiCaller";
import SearchButton from './../components/SearchButton'
import Logo from './../components/Logo'

const widthConst = Dimensions.get('screen').width;

export default  function SocietyScreen({ route, navigation }) {
    const host = route.params;
    const [text, onChangeText] = React.useState("");
    const [outerArr, onSearch] = React.useState([]);
    console.log("SOCIETYSCREEN",route.params)
    React.useEffect(()=>handleSearch(),[text])
    const handleSearch =() =>{
      if(text.length==0){
        return
      }
      api.callUserSearch({exp:text})
      .then(response => response.json())
      .then(returnedData => {
        if(returnedData == []){
          onSearch([])
        }
            const innerArr = Object.values(returnedData);
            onSearch(innerArr)
        })
      }
      
      function Item({props} ){
        var role,department;
        var roles=(props.userUnits.length != 0)
        if (roles){
          role =props.userUnits[0].role
          department =props.userUnits[0].departmentName
        }else{
          role ="";
          department="";
        }
          return (
            <TouchableOpacity style = {styles.item}
                onPress={ () =>{navigation.navigate("PersonInfoScreen", {props,host})}}>
              <Text style ={styles.itemText} >
                {props.name} {props.surname}{"\n"}
                {role}  {department}
              </Text>
        
            </TouchableOpacity>
            );
          }  

  return (
     <SafeAreaView style={styles.container, {flex:1}} >
       <View style= {{flex:0.5}}>
       <Logo header="Społeczność"
        ></Logo>
       </View>
       <View style ={{flex:1, alignSelf:'center', justifyContent:'center'}}>
             <SearchButton
        text = "Arkusz współdzielony"
      />
       </View>
       <View style={{flex:0.5,flexDirection:"row", padding: 10 }}>
        <TextInput
          placeholder={'Szukaj'}
          style={styles.input}
          onChangeText={onChangeText}
          value={text}
        />
       </View>
      <View style = {styles.listcontainer}>
        <FlatList
        data={outerArr }
        renderItem={( {item} ) => <Item props= {item} />}
        contentContainerStyle={styles.list}
        keyExtractor={(item) => item.userId}
      />
      </View>
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
   container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'top',
  //  color: 'white',
  },
  listcontainer :{ 
    flex :3  ,
     borderWidth: 1, 
     borderColor: 'black'
    },
  input: {
    //position : 'absolute',
    top:150,
    height: 40,
    margin: 12,
    borderWidth: 1,
    padding: 10,
    flex : 3

  },
    list: {
    alignItems: 'bottom',
    justifyContent: 'bottom',
    width: widthConst,
    padding: 10,
    flex: 1,
    flexGrow: 1,

  },
  item :{
       height:60,
        alignItems:'left',
         alignContent:'left',
         borderWidth : 1,
         borderRadius : 2,
         borderColor : 'black',
         padding : 2,
            flexGrow: 1,
        flex: 1,
  },
  itemText :{
    fontSize:20, 
    flexWrap: 'wrap',
    flexShrink:1,
    alignSelf :'left',
    alignItems:'left',
    alignContent:'left',
  }
});
