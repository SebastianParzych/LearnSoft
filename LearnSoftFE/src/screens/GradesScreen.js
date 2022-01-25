import * as React from 'react';
import { Button, View, Text ,FlatList,PreviewLayout, Dimensions , StyleSheet ,SafeAreaView} from 'react-native';
import { NavigationContainer } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import  api from "../api/ApiCaller";
import LogoComponent from './../components/Logo'



const widthConst = Dimensions.get('screen').width;




export default   function GradeScreen({ navigation }) {

    function Item({props} ){
    return (
      <View style={{flexDirection:"row", borderWidth:2, borderRadius: 2,  flex:1, padding: 5}}>
        <View style ={styles.FirstItem}>
            <Text >
                {props.name}
             </Text>
        </View>
                <View style ={styles.markItem}>
            <Text>
                {props.weightedMark}
             </Text>

        </View>
                <View style ={styles.markItem}>
            <Text>
                {props.finalMark}
             </Text>

        </View>
      </View>
    );

  }    


  const outerArr=[];    
  api.callCoursesGrades({userid:3})
  	.then(response => response.json())
    .then(returnedData => {
              console.log(returnedData)
		          const innerArr = Object.values(returnedData);
              outerArr.push(...innerArr);
          })
      
  return (
    <SafeAreaView style={styles.container}>
          <LogoComponent header='Oceny'/>
      <FlatList
     
        data={outerArr }
        renderItem={( {item} ) => <Item props= {item} />}
       contentContainerStyle={styles.list}
      />
      <View style={styles.enappdWrapper}>
      </View>
    </SafeAreaView>
  );
}



const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
  },
  FirstItem:{
          width:widthConst/2+20,
           height:60,
           backgroundColor:'white',
           borderWidth:1,
           flex:4,
           padding:20,
           alignContent:'center',
           alignItems :'center',
  },
  markItem : { 
    height:60,
    backgroundColor:'white',
    borderWidth:1,
    flex:0.5,
    padding:10
},
  list: {
    alignItems: 'center',
    justifyContent: 'center',
    width: widthConst,
    padding: 10,
    flex: 1,
    flexGrow: 1,
  },
  enappdWrapper: {
    position: 'absolute',
    bottom: 0
  },

  item: {
    marginTop: 0,
    width: 300,
    backgroundColor: 'white',
    flexDirection: 'row',
    alignItems: 'flex-start',
    paddingHorizontal: 5,
    padding: 5 ,
    borderWidth: 1, 

  },

});